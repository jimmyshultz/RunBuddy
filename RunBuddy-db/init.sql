-- Enable PostGIS extension for geographic types
CREATE EXTENSION IF NOT EXISTS postgis;

-- Users table
CREATE TABLE users (
  id SERIAL PRIMARY KEY,
  name VARCHAR(100) NOT NULL,
  email VARCHAR(100) UNIQUE NOT NULL,
  google_id VARCHAR(255),
  facebook_id VARCHAR(255),
  strava_profile VARCHAR(255), -- Link to Strava profile
  location GEOGRAPHY(POINT), -- For storing user location (latitude, longitude)
  created_at TIMESTAMP DEFAULT NOW(), -- Set once on creation
  updated_at TIMESTAMP DEFAULT NOW() -- Will be updated via trigger
);

-- Preferences table
CREATE TABLE preferences (
  id SERIAL PRIMARY KEY,
  user_id INT REFERENCES users(id),
  weekly_distance_preference DECIMAL(5, 2), -- Preferred weekly running distance
  easy_run_pace_preference INTERVAL, -- Preferred easy run pace (stored as time interval, e.g., minutes per mile/km)
  time_preference VARCHAR(20)[] CHECK (time_preference <@ ARRAY['morning', 'afternoon', 'evening']::VARCHAR[]), -- Array for time preferences
  created_at TIMESTAMP DEFAULT NOW(), -- Set once on creation
  updated_at TIMESTAMP DEFAULT NOW() -- Will be updated via trigger
);

-- Matches table (to track partnerships between runners)
CREATE TABLE matches (
  id SERIAL PRIMARY KEY,
  user1_id INT REFERENCES users(id),
  user2_id INT REFERENCES users(id),
  status VARCHAR(20) DEFAULT 'pending', -- Pending, accepted, rejected
  created_at TIMESTAMP DEFAULT NOW(), -- Set once on creation
  updated_at TIMESTAMP DEFAULT NOW() -- Will be updated via trigger
);

-- Create function to update updated_at on modification
CREATE OR REPLACE FUNCTION update_updated_at_column()
RETURNS TRIGGER AS $$
BEGIN
  NEW.updated_at = NOW();
  RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Trigger for Users table
CREATE TRIGGER update_users_updated_at BEFORE UPDATE ON users
FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

-- Trigger for Preferences table
CREATE TRIGGER update_preferences_updated_at BEFORE UPDATE ON preferences
FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();

-- Trigger for Matches table
CREATE TRIGGER update_matches_updated_at BEFORE UPDATE ON matches
FOR EACH ROW EXECUTE FUNCTION update_updated_at_column();