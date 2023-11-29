--Query for Player Summary
SELECT p.PlayerName, c.CharacterName, g.GameStartDate, g.GameID, g.GameDescription
FROM Player p
	INNER JOIN [Character] c ON p.PlayerID = c.PlayerID
	INNER JOIN Game g ON c.GameID = g.GameID
GROUP BY p.PlayerName, g.GameStartDate, c.CharacterName, g.GameID, g.GameDescription
ORDER BY g.GameStartDate ASC

--Query for Highest Stats
SELECT Stat.StatNamme, ListCharacterStats.StatValue, Character.CharacterName
FROM Stat s
	INNER JOIN ListCharacterStats l ON s.StatsID = ListCharacterStats.ID 
	--INNER JOIN Character c ON ListCharacterStats.????
WHERE StatsID = @StatsID 
GROUP BY Stat.StatsID, Stat.StatValue
ORDER BY Stat.StatValue ASC
