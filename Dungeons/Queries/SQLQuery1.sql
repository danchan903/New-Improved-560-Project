--Query for Player Summary
SELECT p.PlayerName, c.CharacterName, g.GameStartDate, g.GameID, g.GameDescription
FROM Player p
	INNER JOIN [Character] c ON p.PlayerID = c.PlayerID
	INNER JOIN Game g ON c.GameID = g.GameID
GROUP BY p.PlayerName, g.GameStartDate, c.CharacterName, g.GameID, g.GameDescription
ORDER BY g.GameStartDate ASC

--Query for displaying all stats
SELECT c.CharacterName, l.Strength, l.Dexterity, l.Constitution, l.Intelligence, l.Charisma, l.Wisdom
FROM ListCharacterStats l
	INNER JOIN [Character] c ON l.CharacterName = c.CharacterName
GROUP BY c.CharacterName, l.Strength, l.Dexterity, l.Constitution, l.Intelligence, l.Charisma, l.Wisdom

--Query for Displaying all descriptions of a character
SELECT c.CharacterName, c.CharacterDescription, g.GameDescription, cl.ClassDescription, r.RaceDescription
FROM [Character] c
	INNER JOIN Race r ON c.RaceID = r.RaceID
	INNER JOIN Class cl ON c.ClassID = cl.ClassID 
	INNER JOIN Game g ON c.GameID = g.GameID 
GROUP BY c.CharacterName, c.CharacterDescription, g.GameDescription, cl.ClassDescription, r.RaceDescription
ORDER BY c.CharacterName DESC

--Query for counting the number of spells for each class
SELECT c.ClassID, c.ClassType, COUNT(s.SpellID) AS SpellCount, c.ClassDescription
FROM Class c
	INNER JOIN Spells s ON c.ClassID = s.ClassID
GROUP BY c.ClassID, c.ClassType, c.ClassDescription
ORDER BY SpellCount DESC