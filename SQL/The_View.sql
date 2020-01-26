----SELECT *
----FROM CSAttribute
----SELECT *
----FROM CSAnswers
----SELECT *
----FROM CSUserDefDataHeader
----SELECT *
----FROM CSUserDefDataDetail 

--SELECT NEWID()
----SELECT *
----FROM CSUserDefDataHeader
----	JOIN CSUserDefDataDetail 
----		ON CSUserDefDataHeader.CompanyID = CSUserDefDataDetail.CompanyID 
----			AND CSUserDefDataHeader.UserDefDataID = CSUserDefDataDetail.UserDefDataID


--SELECT CSUserDefDataHeader.CompanyID
--	, CSUserDefDataHeader.UserDefDataID
--	, CSUserDefDataHeader.UserDefDataCD
--	, CONVERT(nvarchar(256),CSAnswers1.Value) Attribute1
--	, CONVERT(nvarchar(256),CSAnswers2.Value) Attribute2
--	, CONVERT(nvarchar(256),CSAnswers3.Value) Attribute3
--	, CONVERT(nvarchar(256),CSAnswers4.Value) Attribute4
--	, CONVERT(nvarchar(256),CSAnswers5.Value) Attribute5
--	, CONVERT(nvarchar(256),CSAnswers6.Value) Attribute6
--	, CONVERT(nvarchar(256),CSAnswers7.Value) Attribute7
--	, CONVERT(nvarchar(256),CSAnswers8.Value) Attribute8
--	, CONVERT(nvarchar(256),CSAnswers9.Value) Attribute9
--	, CONVERT(nvarchar(256),CSAnswers10.Value) Attribute10
--	, CONVERT(nvarchar(256),CSAnswers11.Value) Attribute11
--	, CONVERT(nvarchar(256),CSAnswers12.Value) Attribute12
--	, CONVERT(nvarchar(256),CSAnswers13.Value) Attribute13
--	, CONVERT(nvarchar(256),CSAnswers14.Value) Attribute14
--	, CONVERT(nvarchar(256),CSAnswers15.Value) Attribute15
--	, CONVERT(nvarchar(256),CSAnswers16.Value) Attribute16
--	, CONVERT(nvarchar(256),CSAnswers17.Value) Attribute17
--	, CONVERT(nvarchar(256),CSAnswers18.Value) Attribute18
--	, CONVERT(nvarchar(256),CSAnswers19.Value) Attribute19
--	, CONVERT(nvarchar(256),CSAnswers20.Value) Attribute20
--	, CONVERT(nvarchar(256),CSAnswers21.Value) Attribute21
--	, CONVERT(nvarchar(256),CSAnswers22.Value) Attribute22
--	, CONVERT(nvarchar(256),CSAnswers23.Value) Attribute23
--	, CONVERT(nvarchar(256),CSAnswers24.Value) Attribute24
--	, CONVERT(nvarchar(256),CSAnswers25.Value) Attribute25
--	, CONVERT(nvarchar(256),CSAnswers26.Value) Attribute26
--	, CONVERT(nvarchar(256),CSAnswers27.Value) Attribute27
--	, CONVERT(nvarchar(256),CSAnswers28.Value) Attribute28
--	, CONVERT(nvarchar(256),CSAnswers29.Value) Attribute29
--	, CONVERT(nvarchar(256),CSAnswers30.Value) Attribute30
--	, CONVERT(nvarchar(256),CSAnswers31.Value) Attribute31
--	, CONVERT(nvarchar(256),CSAnswers32.Value) Attribute32
--	, CONVERT(nvarchar(256),CSAnswers33.Value) Attribute33
--	, CONVERT(nvarchar(256),CSAnswers34.Value) Attribute34
--	, CONVERT(nvarchar(256),CSAnswers35.Value) Attribute35
--	, CONVERT(nvarchar(256),CSAnswers36.Value) Attribute36
--	, CONVERT(nvarchar(256),CSAnswers37.Value) Attribute37
--	, CONVERT(nvarchar(256),CSAnswers38.Value) Attribute38
--	, CONVERT(nvarchar(256),CSAnswers39.Value) Attribute39
--	, CONVERT(nvarchar(256),CSAnswers40.Value) Attribute40
--	, CONVERT(nvarchar(256),CSAnswers41.Value) Attribute41
--	, CONVERT(nvarchar(256),CSAnswers42.Value) Attribute42
--	, CONVERT(nvarchar(256),CSAnswers43.Value) Attribute43
--	, CONVERT(nvarchar(256),CSAnswers44.Value) Attribute44
--	, CONVERT(nvarchar(256),CSAnswers45.Value) Attribute45
--	, CONVERT(nvarchar(256),CSAnswers46.Value) Attribute46
--	, CONVERT(nvarchar(256),CSAnswers47.Value) Attribute47
--	, CONVERT(nvarchar(256),CSAnswers48.Value) Attribute48
--	, CONVERT(nvarchar(256),CSAnswers49.Value) Attribute49
--	, CONVERT(nvarchar(256),CSAnswers50.Value) Attribute50
--FROM CSUserDefDataHeader
--	JOIN CSUserDefDataDetail 
--		ON CSUserDefDataHeader.CompanyID = CSUserDefDataDetail.CompanyID 
--			AND CSUserDefDataHeader.UserDefDataID = CSUserDefDataDetail.UserDefDataID
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers1
--		ON CSUserDefDataDetail.CompanyID = CSAnswers1.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers1.AttributeID 
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers2
--		ON CSUserDefDataDetail.CompanyID = CSAnswers2.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers2.AttributeID 
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers3
--		ON CSUserDefDataDetail.CompanyID = CSAnswers3.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers3.AttributeID 
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers4
--		ON CSUserDefDataDetail.CompanyID = CSAnswers4.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers4.AttributeID 
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers5
--		ON CSUserDefDataDetail.CompanyID = CSAnswers5.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers5.AttributeID 
--	LEFT JOIN CSAnswers (NOLOCK) CSAnswers6
--		ON CSUserDefDataDetail.CompanyID = CSAnswers6.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers6.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers7
--		ON CSUserDefDataDetail.CompanyID = CSAnswers7.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers7.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers8
--		ON CSUserDefDataDetail.CompanyID = CSAnswers8.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers8.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers9
--		ON CSUserDefDataDetail.CompanyID = CSAnswers9.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers9.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers10
--		ON CSUserDefDataDetail.CompanyID = CSAnswers10.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers10.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers11
--		ON CSUserDefDataDetail.CompanyID = CSAnswers11.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers11.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers12
--		ON CSUserDefDataDetail.CompanyID = CSAnswers12.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers12.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers13
--		ON CSUserDefDataDetail.CompanyID = CSAnswers13.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers13.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers14
--		ON CSUserDefDataDetail.CompanyID = CSAnswers14.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers14.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers15
--		ON CSUserDefDataDetail.CompanyID = CSAnswers15.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers15.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers16
--		ON CSUserDefDataDetail.CompanyID = CSAnswers16.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers16.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers17
--		ON CSUserDefDataDetail.CompanyID = CSAnswers17.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers17.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers18
--		ON CSUserDefDataDetail.CompanyID = CSAnswers18.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers18.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers19
--		ON CSUserDefDataDetail.CompanyID = CSAnswers19.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers19.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers20
--		ON CSUserDefDataDetail.CompanyID = CSAnswers20.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers20.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers21
--		ON CSUserDefDataDetail.CompanyID = CSAnswers21.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers21.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers22
--		ON CSUserDefDataDetail.CompanyID = CSAnswers22.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers22.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers23
--		ON CSUserDefDataDetail.CompanyID = CSAnswers23.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers23.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers24
--		ON CSUserDefDataDetail.CompanyID = CSAnswers24.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers24.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers25
--		ON CSUserDefDataDetail.CompanyID = CSAnswers25.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers25.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers26
--		ON CSUserDefDataDetail.CompanyID = CSAnswers26.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers26.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers27
--		ON CSUserDefDataDetail.CompanyID = CSAnswers27.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers27.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers28
--		ON CSUserDefDataDetail.CompanyID = CSAnswers28.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers28.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers29
--		ON CSUserDefDataDetail.CompanyID = CSAnswers29.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers29.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers30
--		ON CSUserDefDataDetail.CompanyID = CSAnswers30.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers30.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers31
--		ON CSUserDefDataDetail.CompanyID = CSAnswers31.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers31.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers32
--		ON CSUserDefDataDetail.CompanyID = CSAnswers32.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers32.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers33
--		ON CSUserDefDataDetail.CompanyID = CSAnswers33.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers33.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers34
--		ON CSUserDefDataDetail.CompanyID = CSAnswers34.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers34.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers35
--		ON CSUserDefDataDetail.CompanyID = CSAnswers35.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers35.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers36
--		ON CSUserDefDataDetail.CompanyID = CSAnswers36.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers36.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers37
--		ON CSUserDefDataDetail.CompanyID = CSAnswers37.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers37.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers38
--		ON CSUserDefDataDetail.CompanyID = CSAnswers38.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers38.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers39
--		ON CSUserDefDataDetail.CompanyID = CSAnswers39.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers39.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers40
--		ON CSUserDefDataDetail.CompanyID = CSAnswers40.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers40.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers41
--		ON CSUserDefDataDetail.CompanyID = CSAnswers41.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers41.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers42
--		ON CSUserDefDataDetail.CompanyID = CSAnswers42.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers42.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers43
--		ON CSUserDefDataDetail.CompanyID = CSAnswers43.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers43.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers44
--		ON CSUserDefDataDetail.CompanyID = CSAnswers44.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers44.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers45
--		ON CSUserDefDataDetail.CompanyID = CSAnswers45.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers45.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers46
--		ON CSUserDefDataDetail.CompanyID = CSAnswers46.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers46.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers47
--		ON CSUserDefDataDetail.CompanyID = CSAnswers47.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers47.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers48
--		ON CSUserDefDataDetail.CompanyID = CSAnswers48.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers48.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers49
--		ON CSUserDefDataDetail.CompanyID = CSAnswers49.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers49.AttributeID 
--	LEFT JOIN CSAnswers CSAnswers50
--		ON CSUserDefDataDetail.CompanyID = CSAnswers50.CompanyID 
--			AND CSUserDefDataDetail.DataElementName = CSAnswers50.AttributeID 
--WHERE CSUserDefDataHeader.UserDefDataCD = '123'

SELECT a.RefNoteID   as TheDataKeyField,
       MAX(CASE b.SequenceNo WHEN 1 THEN b.DataElementName ELSE '' END) AS Attribute1Name,
       MAX(CASE b.SequenceNo WHEN 1 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute1,
	   MAX(CASE b.SequenceNo WHEN 2 THEN b.DataElementName ELSE '' END) AS Attribute2Name,
	   MAX(CASE b.SequenceNo WHEN 2 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute2,
	   MAX(CASE b.SequenceNo WHEN 3 THEN b.DataElementName ELSE '' END) AS Attribute3Name,
       MAX(CASE b.SequenceNo WHEN 3 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute3,
	   MAX(CASE b.SequenceNo WHEN 4 THEN b.DataElementName ELSE '' END) AS Attribute4Name,
       MAX(CASE b.SequenceNo WHEN 4 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute4,
	   MAX(CASE b.SequenceNo WHEN 5 THEN b.DataElementName ELSE '' END) AS Attribute5Name,
       MAX(CASE b.SequenceNo WHEN 5 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute5,
	   MAX(CASE b.SequenceNo WHEN 6 THEN b.DataElementName ELSE '' END) AS Attribute6Name,
       MAX(CASE b.SequenceNo WHEN 6 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute6,
	   MAX(CASE b.SequenceNo WHEN 7 THEN b.DataElementName ELSE '' END) AS Attribute7Name,
       MAX(CASE b.SequenceNo WHEN 7 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute7,
	   MAX(CASE b.SequenceNo WHEN 8 THEN b.DataElementName ELSE '' END) AS Attribute8Name,
       MAX(CASE b.SequenceNo WHEN 8 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute8,
	   MAX(CASE b.SequenceNo WHEN 9 THEN b.DataElementName ELSE '' END) AS Attribute9Name,
       MAX(CASE b.SequenceNo WHEN 9 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute9,
	   MAX(CASE b.SequenceNo WHEN 10 THEN b.DataElementName ELSE '' END) AS Attribute10Name,
       MAX(CASE b.SequenceNo WHEN 10 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute10,
	   MAX(CASE b.SequenceNo WHEN 11 THEN b.DataElementName ELSE '' END) AS Attribute11Name,
       MAX(CASE b.SequenceNo WHEN 11 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute11,
	   MAX(CASE b.SequenceNo WHEN 12 THEN b.DataElementName ELSE '' END) AS Attribute12Name,
       MAX(CASE b.SequenceNo WHEN 12 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute12,
	   MAX(CASE b.SequenceNo WHEN 13 THEN b.DataElementName ELSE '' END) AS Attribute13Name,
       MAX(CASE b.SequenceNo WHEN 13 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute13,
	   MAX(CASE b.SequenceNo WHEN 14 THEN b.DataElementName ELSE '' END) AS Attribute14Name,
       MAX(CASE b.SequenceNo WHEN 14 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute14,
	   MAX(CASE b.SequenceNo WHEN 15 THEN b.DataElementName ELSE '' END) AS Attribute15Name,
       MAX(CASE b.SequenceNo WHEN 15 THEN CONVERT(nvarchar(256),a.Value) ELSE '' END) AS Attribute15
FROM   CSAnswers a
  LEFT OUTER JOIN CSUserDefDataDetail b ON a.CompanyID = b.CompanyID and a.AttributeID = b.DataElementName 
  LEFT OUTER JOIN CSUserDefDataHeader c ON b.CompanyID = c.CompanyID and b.UserDefDataID = c.UserDefDataID
WHERE  a.CompanyID = 2
  AND  c.UserDefDataID = 2
GROUP BY a.RefNoteID, c.UserDefDataCD

select * from CSUserDefDataDetail
