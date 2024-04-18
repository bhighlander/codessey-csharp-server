USE [master]
GO
IF db_id('codesseyapi') IS NULL
    CREATE DATABASE [codesseyapi]
GO
USE [codesseyapi]
GO

DROP TABLE IF EXISTS Entry



-- Create codesseyapi.entry table within the codesseyapi schema
CREATE TABLE Entry (
    Id INTEGER PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    Content TEXT NOT NULL,
    Author INTEGER NOT NULL,
    DateCreated DATETIME NOT NULL,
    Solved BIT NOT NULL
);
GO

-- Insert sample data into codesseyapi.entry table
INSERT INTO Entry (Id, Title, Content, Author, DateCreated, Solved) VALUES
(1, 'API Issue', 'Encountered a 404 error while trying to fetch data from the API.', 2, '2023-09-18T19:47:41', 0),
(2, 'Database Error', 'SQL query is not returning the expected results.', 2, '2023-09-17T19:47:41', 0),
(3, 'React Bug', 'State is not updating as expected in a React component.', 2, '2023-09-16T19:47:41', 0),
(4, 'Python Script', 'Created a Python script to automate a routine task.', 2, '2023-09-15T19:47:41', 0),
(5, 'Code Review', 'Reviewed a colleague''s pull request and provided feedback.', 2, '2023-09-14T19:47:41', 0),
(6, 'Frontend Update', 'Updated the frontend to improve user experience.', 2, '2023-09-13T19:47:41', 0),
(7, 'Backend Optimization', 'Optimized some backend logic to improve performance.', 2, '2023-09-12T19:47:41', 0),
(8, 'Security Patch', 'Fixed a security vulnerability in the code.', 2, '2023-09-11T19:47:41', 0);
