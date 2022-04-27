	DECLARE @ROW_COUNT int
	SELECT @ROW_COUNT = COUNT(*) FROM FieldStates
	IF @ROW_COUNT = 0
	BEGIN
		PRINT 'Add rows in table FieldStates'
		INSERT INTO FieldStates VALUES(1, N'Read-only')
		INSERT INTO FieldStates VALUES(2, N'Editable')
		INSERT INTO FieldStates VALUES(3, N'Hidden')
		INSERT INTO FieldStates VALUES(4, N'Unavailable')
	END

	SELECT @ROW_COUNT = COUNT(*) FROM DataSourceTypes
	IF @ROW_COUNT = 0
	BEGIN
		PRINT 'Add rows in table DataSourceTypes'
		INSERT INTO DataSourceTypes VALUES(1, N'None')
		INSERT INTO DataSourceTypes VALUES(2, N'ListValues')
		INSERT INTO DataSourceTypes VALUES(3, N'WS')
		INSERT INTO DataSourceTypes VALUES(4, N'REST')
		INSERT INTO DataSourceTypes VALUES(5, N'Proxy')
		INSERT INTO DataSourceTypes VALUES(6, N'DBQuery')
	END
	SELECT @ROW_COUNT = COUNT(*) FROM TaskTypes
	IF @ROW_COUNT = 0
	BEGIN
		PRINT 'Add rows in table TaskTypes'
		INSERT INTO TaskTypes VALUES(N'E101', N'Ε101-ΓΝΩΜΑΤΕΥΣΕΙΣ (ΕΠΙ ΝΕΩΝ ΠΑΡΟΧΩΝ)',                            1)
		INSERT INTO TaskTypes VALUES(N'E102', N'Ε102-ΕΚΤΑΚΤΑ ΠΕΡΙΣΤΑΤΙΚΑ - ΠΡΟΒΛΗΜΑΤΑ ΠΙΕΣΗΣ (ΥΨΗΛΗ Ή ΧΑΜΗΛΗ)',   1)
		INSERT INTO TaskTypes VALUES(N'E103', N'Ε103-ΕΚΤΑΚΤΑ ΠΕΡΙΣΤΑΤΙΚΑ - ΠΟΙΟΤΗΤΑ ΝΕΡΟΥ',                       1)
		INSERT INTO TaskTypes VALUES(N'E104', N'Ε104-ΕΚΤΑΚΤΑ ΠΕΡΙΣΤΑΤΙΚΑ - ΔΙΑΡΡΟΗ ΣΕ ΒΑΝΑ',                      1)
		INSERT INTO TaskTypes VALUES(N'E105', N'Ε105-ΕΚΤΑΚΤΑ ΠΕΡΙΣΤΑΤΙΚΑ - ΔΙΑΡΡΟΗ ΣΕ ΕΙΔΙΚΗ ΠΑΡΟΧΗ',             1)
		INSERT INTO TaskTypes VALUES(N'E106', N'Ε106-ΕΚΤΑΚΤΑ ΠΕΡΙΣΤΑΤΙΚΑ - ΔΙΑΡΡΟΗ ΣΕ ΑΓΩΓΟ',                     1)
		INSERT INTO TaskTypes VALUES(N'E112', N'Ε112-ΑΠΟΜΟΝΟΣΕΙΣ-ΕΠΑΝΑΦΟΡΕΣ',                                     1)
		INSERT INTO TaskTypes VALUES(N'E113', N'Ε113-ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΕΣ ΕΡΓΑΣΙΕΣ',                                 1)
		INSERT INTO TaskTypes VALUES(N'E114', N'Ε114-ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΦΑΝΕΡΩΜΑΤΑ ΔΙΚΤΥΟΥ',                           1)
		INSERT INTO TaskTypes VALUES(N'E115', N'Ε115-ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΧΕΙΡΙΣΜΟΣ',                                    1)
		INSERT INTO TaskTypes VALUES(N'E116', N'Ε116-ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΚΑΘΑΡΙΣΜΟΣ',                                   1)
        INSERT INTO TaskTypes VALUES(N'E117', N'ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΣΥΝΤΗΡΗΣΗ/ΤΟΠΟΘΕΤΗΣΗ',                              1)
        INSERT INTO TaskTypes VALUES(N'E118', N'ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΣΥΝΤΗΡΗΣΗ/ΑΝΤΙΚΑΤΑΣΤΑΣΗ',                           1)
		INSERT INTO TaskTypes VALUES(N'E119', N'Ε119-ΕΛΕΓΧΟΣ ΒΑΝΩΝ-ΑΝΥΨΩΣΗ/ΚΑΤΑΒΙΒΑΣΗ',                           1)
		INSERT INTO TaskTypes VALUES(N'E120', N'Ε120-ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΕΣ ΕΡΓΑΣΙΕΣ',                                 1)
        INSERT INTO TaskTypes VALUES(N'E121', N'ΜΠΛΕ ΒΑΝΕΣ-ΣΥΝΤΗΡΗΣΗ',                                            1)
        INSERT INTO TaskTypes VALUES(N'E122', N'ΔΕΞΑΜΕΝΕΣ-ΕΠΙΘΕΩΡΗΣΗ',                                            1)
        INSERT INTO TaskTypes VALUES(N'E123', N'ΔΕΞΑΜΕΝΕΣ-ΕΡΓΑΣΙΕΣ ΣΥΝΤΗΡΗΣΗΣ',                                   1)
		INSERT INTO TaskTypes VALUES(N'E124', N'Ε124-ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΕΣ ΕΡΓΑΣΙΕΣ',                                 1)
        INSERT INTO TaskTypes VALUES(N'E125', N'PRV-ΕΠΙΘΕΩΡΗΣΗ-ΡΥΘΜΙΣΗ-ΧΕΙΡΙΣΜΟΣ',                                1)
        INSERT INTO TaskTypes VALUES(N'E126', N'PRV-ΓΕΝΙΚΗ ΣΥΝΤΗΡΗΣΗ-ΚΑΘΑΡΙΣΜΟΣ ΦΙΛΤΡΩΝ',                         1)
        INSERT INTO TaskTypes VALUES(N'E127', N'PRV-ΓΕΝΙΚΗ ΣΥΝΤΗΡΗΣΗ-ΚΑΘΑΡΙΣΜΟΣ ΦΡΕΑΤΙΩΝ',                        1)
        INSERT INTO TaskTypes VALUES(N'E128', N'PRV-ΔΥΣΛΕΙΤΟΥΡΓΙΑ-ΕΠΙΣΚΕΥΗ',                                      1)
        INSERT INTO TaskTypes VALUES(N'E301', N'ΣΥΝΤΗΡΗΣΗ-ΕΠΙΣΚΕΥΗ ΒΛΑΒΗΣ ΔΙΚΤΥΟΥ',                               1)
        INSERT INTO TaskTypes VALUES(N'E401', N'ΜΕΤΡΗΤΩΝ (ΤΕΧΝΙΚΕΣ ΕΝΕΡΓΕΙΕΣ BCC)',                               1)
        INSERT INTO TaskTypes VALUES(N'E700', N'ΕΝΤΟΠΙΣΜΟΣ ΑΦΑΝΟΥΣ ΔΙΑΡΡΟΗΣ',                                     1)
        INSERT INTO TaskTypes VALUES(N'E701', N'ΠΡΟΒΛΗΜΑ ΣΕ ΤΗΛΕΜΕΤΡΙΚΗ ΔΙΑΤΑΞΗ',                                 1)
        INSERT INTO TaskTypes VALUES(N'E800', N'ΕΝΤΟΠΙΣΜΟΣ ΑΦΑΝΟΥΣ ΔΙΑΡΡΟΗΣ',                                     1)
        INSERT INTO TaskTypes VALUES(N'E801', N'ΒΛΑΒΗ ΑΝΤΛΙΟΣΤΑΣΙΟΥ',                                             1)
        INSERT INTO TaskTypes VALUES(N'E802', N'ΠΕΡΙΓΡΑΦΗ ΧΕΙΡΙΣΜΩΝ',                                             1)
        INSERT INTO TaskTypes VALUES(N'E803', N'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΣΥΝΤΗΡΗΣΗ',                                      1)
        INSERT INTO TaskTypes VALUES(N'E1001', N'ΧΗΜΕΙΟ-ΠΟΙΟΤΙΚΟΣ ΕΛΕΓΧΟΣ',                                       1)

	END
