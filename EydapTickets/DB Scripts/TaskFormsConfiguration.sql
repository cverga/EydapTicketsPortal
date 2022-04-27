
	DECLARE @ROW_COUNT int

	SELECT @ROW_COUNT = COUNT(*) FROM Categories
	IF @ROW_COUNT = 0
	BEGIN
		PRINT 'Add rows in table Categories'
		INSERT INTO Categories([CategoryName], [ParentCategoryId], [AllowNew], [AllowView], [RowStatus]) VALUES (N'Default', null, 0, 0, -100)
	END

	SELECT @ROW_COUNT = COUNT(*) FROM Fields
	IF @ROW_COUNT = 0
	BEGIN
		PRINT 'Add rows in table Fields'
		INSERT INTO Fields
			SELECT NEWID(), Entity, NAME, DataType, Size, Nullable  FROM (
				SELECT DISTINCT C.NAME, T.NAME AS Entity, P.NAME AS DataType, C.is_nullable AS Nullable, CASE P.NAME WHEN 'nvarchar' THEN c.max_length / 2 ELSE c.max_length END AS Size
				--T.NAME AS [TABLE NAME], C.NAME AS [COLUMN NAME], P.NAME AS [DATA TYPE], P.MAX_LENGTH AS[SIZE],   CAST(P.PRECISION AS VARCHAR) +'/'+ CAST(P.SCALE AS VARCHAR) AS [PRECISION/SCALE]
				FROM SYS.OBJECTS AS T
				JOIN SYS.COLUMNS AS C
				ON T.OBJECT_ID=C.OBJECT_ID
				JOIN SYS.TYPES AS P
				ON C.SYSTEM_TYPE_ID=P.SYSTEM_TYPE_ID
				WHERE T.TYPE_DESC='USER_TABLE' AND T.name IN ('Incidents', 'Visits') AND P.name <> 'sysname'
				) AS T1
	END

	SELECT @ROW_COUNT = COUNT(*) FROM CategoriesFields
	IF @ROW_COUNT = 0
	BEGIN
		------------------------------------------------------------------
		-- Define fields for Incidents table
		------------------------------------------------------------------
		PRINT 'Add rows in table CategoriesFields - Incidents'
		INSERT INTO CategoriesFields(CategoryId, FieldId, InternalName, Entity, FieldExtensionId, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, SortOrder, LayoutOrder, ControlTypeInNewForm, ControlTypeInEditForm, ControlTypeInViewForm, RowStatus, RowInserted, RowLastUpdated, DataSourceTypeId)
			SELECT (SELECT Id FROM Categories WHERE CategoryName = 'Default'), Id, FieldName, Entity, 0, 4, 4, 4, Nullable ^ 1, Nullable ^ 1, 0, 0, dbo.fnMapDataTypeToUIControlType(FieldType), dbo.fnMapDataTypeToUIControlType(FieldType), 'textbox', 0, GETDATE(), GETDATE(), 1
			FROM Fields
			WHERE Entity = 'Incidents'

        UPDATE CategoriesFields SET SortOrder = 100 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Ticket Trace ID' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('TT_Id') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 100 , LayoutOrder = 1 , LayoutGroupId = 0 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = '1022 ID' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('ID1022') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 110 , LayoutOrder = 0 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αναγγελίας' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('HmerominiaAnagelias') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 110 , LayoutOrder = 1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Ωρα Αναγγελίας' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('OraAnagelias') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 120 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Ονομα Καλούντος' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('OnomaKalountos') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 130 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Ονομα Καταναλωτή' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('OnomaKatanaloti') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 140 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Είδος Προβλήματος' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('EidosProblimatosDescr') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 150 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Αριθμός Μητρώου' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('ArithmosMitroou') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 160 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Αριθμός Μετρητή' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('ArithmosMetriti') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 170 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Αριθμός Λογαριασμού' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('ArithmosLogariasmou') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 180 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Συντεταγμένες Βλάβης Χ' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('SyntetagmenesVlavis_GeogrMikos') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 190 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Συντεταγμένες Βλάβης Ψ' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('SyntetagmenesVlavis_GeogrPlatos') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Αιτία' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('AitiaDescr') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , ControlTypeInNewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Παρατηρήσεις' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('Comments') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInViewForm = 2 , FieldStateInEditForm = 2 , NameLocale1 = 'Συσχετισμένο' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΜΒΑΝΤΟΣ'  WHERE InternalName IN ('RelatedID1022') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Δήμος' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Municipality') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Περιοχή' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Perioxi') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Οδός' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Street_Name') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Αριθμός' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Street_Number') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 340 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Οδός 2' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Odos2') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Οδός 3' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Odos3') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 360 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'ΤΚ' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('TaxKodikas') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 370 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Τηλέφωνο Επικ' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Customer_Phone') AND Entity = 'Incidents'
        UPDATE CategoriesFields SET SortOrder = 380 , LayoutOrder = -1 , LayoutGroupId = 200 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale1 = 'Οροφος' , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('Orofos') AND Entity = 'Incidents'
            
        ------------------------------------------------------------------
		-- Define fields for Visits table
		------------------------------------------------------------------
		PRINT 'Add rows in table CategoriesFields - Visits'
		INSERT INTO CategoriesFields(CategoryId, FieldId, InternalName, Entity, FieldExtensionId, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, SortOrder, LayoutOrder, ControlTypeInNewForm, ControlTypeInEditForm, ControlTypeInViewForm, RowStatus, RowInserted, RowLastUpdated, DataSourceTypeId)
			SELECT (SELECT Id FROM Categories WHERE CategoryName = 'Default'), Id, FieldName, Entity, 0, 4, 4, 4, Nullable ^ 1, Nullable ^ 1, 0, 0, dbo.fnMapDataTypeToUIControlType(FieldType), dbo.fnMapDataTypeToUIControlType(FieldType), 'textbox', 0, GETDATE(), GETDATE(), 1
			FROM Fields
			WHERE Entity = 'Visits'

		-- Set general fields properties

		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInEditForm = 3 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox'  WHERE InternalName IN ('AssignmentId') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInEditForm = 3 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Α/Α'  WHERE InternalName IN ('Task_Id') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInEditForm = 1 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Εργασία Συνεργείου'  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Σχόλια'  WHERE InternalName IN ('Comments') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Κατάσταση Ανάθεσης' , DataSourceTypeId = 2 , DataSource = 'Ανοιχτή;Ολοκληρωμένη'  WHERE InternalName IN ('Status') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox'  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Α/Α Συμβάντος'  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Συνεργείο Επέμβασης' , DataSourceTypeId = 6 , DataSource = 'SELECT PersonnelID AS ValueInt, CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' ''  + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText' , FieldExtension4 = 'MULTISELECT'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Συνεργείο Ελέγχου' , DataSourceTypeId = 6 , DataSource = 'SELECT PersonnelID AS ValueInt, CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' '' + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText' , FieldExtension4 = 'MULTISELECT'  WHERE InternalName IN ('SynergeioElegxou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Συνεργείο Απομόνωσης' , DataSourceTypeId = 6 , DataSource = 'SELECT PersonnelID AS ValueInt, CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' '' + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText' , FieldExtension4 = 'MULTISELECT'  WHERE InternalName IN ('SynergeioApomonosis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Συνεργείο Επαναφοράς' , DataSourceTypeId = 6 , DataSource = 'SELECT PersonnelID AS ValueInt, CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' '' + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText' , FieldExtension4 = 'MULTISELECT'  WHERE InternalName IN ('SynergeioEpanaforas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 500 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Ελέγχου' , NameLocale9 = 'Στοιχεία Βάρδιας'  WHERE InternalName IN ('ControlDate') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 500 , LayoutOrder = 1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Ελέγχου' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}' , NameLocale9 = 'Στοιχεία Βάρδιας'  WHERE InternalName IN ('ControlTime') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 400 , LayoutOrder = -2 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Βάρδια Συνεργείου' , DefaultValue = 'Α' , DataSourceTypeId = 2 , DataSource = 'Α;Β;Γ' , NameLocale9 = 'Στοιχεία Βάρδιας'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Ατόμων' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Πόρισμα ' , NameLocale9 = 'Πληροφορίες'  WHERE InternalName IN ('Porisma') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Ενέργειες' , NameLocale9 = 'Πληροφορίες'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Θέση Γεώτρησης'  WHERE InternalName IN ('PositionOfGeotrisi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Αποτελέσματα Χημείου'  WHERE InternalName IN ('ResultsOfChemeio') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Παρατηρήσεις' , NameLocale9 = 'Πληροφορίες'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'ΜΑΠ'  WHERE InternalName IN ('MAP') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 1000 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Βάνα – Διάμετρος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 1000 , LayoutOrder = 1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αγωγός – Διάμετρος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 1100 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μετρητής – Διάμετρος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('MetritisDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 1100 , LayoutOrder = 1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Πυροσβεστική Παροχή – Διάμετρος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('PyrosvestikiParoxiDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 1200 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ζώνη Πίεσης'  WHERE InternalName IN ('ZoniPiesis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ζώνη'  WHERE InternalName IN ('Zoni') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Ειδοποίηση' , DefaultValue = 'Ραδιοτηλεοπτικά' , DataSourceTypeId = 2 , DataSource = 'Ραδιοτηλεοπτικά;Με ίδια μέσα'  WHERE InternalName IN ('Eidopoiisi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Απομόνωσης'  WHERE InternalName IN ('HmerominiaApomonosis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Απομόνωσης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraApomonosis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Εκπλυση Τέρματος'  WHERE InternalName IN ('EkplisiTermatos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διάμετρος Πυροσβεστικού Γερανού' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('PyrosvestikouGeranouDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αναχώρησης'  WHERE InternalName IN ('Apomonosi_HmerominiaAnaxorisis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αναχώρησης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Apomonosi_OraAnaxorisis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αφιξης'  WHERE InternalName IN ('Apomonosi_HmerominiaAfixis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αφιξης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Apomonosi_OraAfixis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Επιστροφής'  WHERE InternalName IN ('Apomonosi_HmerominiaEpistrofis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Επιστροφής' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Apomonosi_OraEpistrofis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Επαναφοράς'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Επαναφοράς' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Ειδος Επαναφοράς' , DefaultValue = 'Μερική' , DataSourceTypeId = 2 , DataSource = 'Μερική;Ολική'  WHERE InternalName IN ('EidosEpanaforas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αναχώρησης'  WHERE InternalName IN ('Epanafora_HmerominiaAnaxorisis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αναχώρησης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Epanafora_OraAnaxorisis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αφιξης'  WHERE InternalName IN ('Epanafora_HmerominiaAfixis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αφιξης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Epanafora_OraAfixis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Επιστροφής'  WHERE InternalName IN ('Epanafora_HmerominiaEpistrofis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Επιστροφής' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('Epanafora_OraEpistrofis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Ατόμων' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('Apomonosi_ArithmosAtomonSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Ατόμων' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Βάρδια Συνεργείου' , DefaultValue = 'Α' , DataSourceTypeId = 2 , DataSource = 'Α;Β;Γ'  WHERE InternalName IN ('Apomonosi_VardiaSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Βάρδια Συνεργείου' , DefaultValue = 'Α' , DataSourceTypeId = 2 , DataSource = 'Α;Β;Γ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Βανών που χειρίστηκαν' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('Apomonosi_ArirthosVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Κατάσταση Βανών που χειρίστηκαν' , DefaultValue = 'Ανοιχτές' , DataSourceTypeId = 2 , DataSource = 'Ανοιχτές;Κλειστές'  WHERE InternalName IN ('Apomonosi_KatastasiVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Βανών που χειρίστηκαν' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('Apomonosi_ThesiVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Συντεταγμένες Βλάβης'  WHERE InternalName IN ('SyntetagmenesVlavis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Υλικό Αγωγού'  WHERE InternalName IN ('AgogosYliko') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Τοποθέτηση Καταγραφικού'  WHERE InternalName IN ('TopothetisiKatagrafikou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = '(Γνωμάτευση) Θέση'  WHERE InternalName IN ('GnomateusiThesi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = '(Γνωμάτευση) Μήκος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('GnomateusiMikos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = '(Γνωμάτευση) Διάμετρος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('GnomateusiDiametros') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = '(Γνωμάτευση) Υλικό'  WHERE InternalName IN ('GnomateusiYliko') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'fileupload' , ControlTypeInViewForm = 'fileupload' , ControlTypeInEditForm = 'fileupload' , NameLocale1 = 'Επισυναπτόμενα Αρχεία' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DataSource = '/VisitsGen/Attachments/[[AssignmentId]]' , FieldExtension4 = '/VisitsGen/UploadFile?[[QUERY_STRING]]' , FieldExtension5 = '{ "fuuid" : "[[SESSION_ID]]" }' , FieldExtension6 = 'data-allowmulti="true" data-allowdelete="false"'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Βανών που χειρίστηκαν' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('Epanafora_ArirthosVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Κατάσταση Βανών που χειρίστηκαν' , DefaultValue = 'Ανοιχτές' , DataSourceTypeId = 2 , DataSource = 'Ανοιχτές;Κλειστές'  WHERE InternalName IN ('Epanafora_KatastasiVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Βανών που χειρίστηκαν' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('Epanafora_ThesiVanonPouXeiristikan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Οχήματα' , DataSourceTypeId = 6 , DataSource = 'SELECT VehicleID AS ValueInt, RTRIM(LTRIM(CONVERT(nvarchar(15), VehicleRegNumber))) + '' - '' + RTRIM(LTRIM(OwnerSurname)) AS DisplayText FROM Vehicles' , FieldExtension1 = 'ValueInt' , FieldExtension2 = 'DisplayText' , FieldExtension4 = 'MULTISELECT'  WHERE InternalName IN ('Oximata') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Προγραμματισμένη Ημερομηνία '  WHERE InternalName IN ('TaskScheduleDate') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Εναρξης Εργασιών'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Εναρξης Εργασιών' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Λήξης Εργασιών'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Λήξης Εργασιών' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ονομα Βάνας'  WHERE InternalName IN ('OnomaVanas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Βάνας' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = 'ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Κατάσταση Βάνας' , FieldExtension1 = 'Ανοιχτή' , FieldExtension2 = 'Κλειστή'  WHERE InternalName IN ('KatastasiVanas') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Είδος Καλύματος'  WHERE InternalName IN ('KalymaEidos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διαστάσεις Καλύματος'  WHERE InternalName IN ('KalymaDiastaseis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Είδος Φρεατίου'  WHERE InternalName IN ('FreatioEidos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διαστάσεις Φρεατίου'  WHERE InternalName IN ('FreatioDiastaseis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Επέμβασης'  WHERE InternalName IN ('HmerominiaEpemvasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Επέμβασης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraEpemvasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox'  WHERE InternalName IN ('OnomaDexamenis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Δεξαμενής' , DataSourceTypeId = 6 , DataSource = 'SELECT DexameniID AS ValueInt, CONVERT(nvarchar(50), ScadaCode) + '' - '' + DexameniName AS DisplayText FROM Dexamenes' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiDexamenis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Θάλαμος Δεξαμενής'  WHERE InternalName IN ('ThalamosDexamenis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdwonlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Σημείο Εκκένωσης' , DefaultValue = 'Αγωγός Ομβρίων' , DataSourceTypeId = 2 , DataSource = 'Αγωγός Ομβρίων;Επιφανειακά'  WHERE InternalName IN ('SimeioEkkenosis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Αντλιών' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ArithmosAntlion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Αντλία (Μεγάλη/Μικρή)' , FieldExtension1 = 'Μεγάλη' , FieldExtension2 = 'Μικρή'  WHERE InternalName IN ('MegaliMikriAntlia') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Είδος Τέρματος' , DataSourceTypeId = 6 , DataSource = 'SELECT EidosTermatosId AS ValueInt, CONVERT(nvarchar(50), EidosTermatosDescription) AS DisplayText FROM EidosTermatos' , FieldExtension1 = 'ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('EidosTermatos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Χειρισμός PRV' , FieldExtension1 = 'Ανοιγμα' , FieldExtension2 = 'Κλείσιμο'  WHERE InternalName IN ('PRV_Xeirismos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Επάρκεια Υλικών' , FieldExtension1 = 'Ναι' , FieldExtension2 = 'Όχι'  WHERE InternalName IN ('EparkeiaYlikon') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Είδος Προβλήματος' , FieldExtension1 = 'Κανένα' , FieldExtension2 = 'Άλλο'  WHERE InternalName IN ('EidosProblimatos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Είδος Επέμβασης' , DataSourceTypeId = 6 , DataSource = 'SELECT EidosEpemvasisId AS ValueInt, CONVERT(nvarchar(50), EidosEpemvasisDescription) AS DisplayText FROM EidosEpemvasis'  WHERE InternalName IN ('EidosEpemvasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist-multi' , ControlTypeInViewForm = 'dropdownlist-multi' , ControlTypeInEditForm = 'dropdownlist-multi' , NameLocale1 = 'Συνεργείο PRV' , DataSourceTypeId = 6 , DataSource = 'SELECT CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' '' + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = 'DisplayText' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('SynergeioPRV') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ονομα PRV'  WHERE InternalName IN ('OnomaPRV') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση PRV' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiPRV') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διάμετρος PRV' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('DiametrosPRV') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Κατάσταση PRV' , FieldExtension1 = 'Ανοιχτή' , FieldExtension2 = 'Κλειστή'  WHERE InternalName IN ('KatastasiPRV') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Βάρδια Συνεργείου' , DefaultValue = 'Α' , DataSourceTypeId = 2 , DataSource = 'Α;Β;Γ'  WHERE InternalName IN ('PRVVardiaSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Ατόμων' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('PRVArithmosAtomonSynergeiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Εργολαβία' , DataSourceTypeId = 6 , DataSource = 'SELECT ErgolavosId AS ValueInt, CONVERT(nvarchar(50), ErgCode) + '' - '' + ErgName AS DisplayText FROM Ergolavoi WHERE ErgolavosIsActive = 1 ' , FieldExtension1 = 'ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('Ergolavia') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'switcher' , ControlTypeInViewForm = 'switcher' , ControlTypeInEditForm = 'switcher' , NameLocale1 = 'Ιδιωτικό' , FieldExtension1 = 'Ναι' , FieldExtension2 = 'Όχι'  WHERE InternalName IN ('Idiotiko') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Τρόπος Εντοπισμού' , DataSourceTypeId = 6 , DataSource = 'SELECT CONVERT(nvarchar(50), TROPOS) AS DisplayText FROM _VLAVESATH_Tway' , FieldExtension1 = 'DisplayText' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('TroposEntopismou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Είδος Βλάβης' , DataSourceTypeId = 6 , DataSource = 'SELECT EIDOS AS ValueString, EIDOS AS DisplayText FROM _VLAVESATH_Teidos' , FieldExtension1 = 'DisplayText' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('EidosVlavis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Αιτία Βλάβης' , DataSourceTypeId = 4 , DataSource = '/VisitsGen/LookupFaultReasons/[[FIELD_VALUE]]?filter=[[CASCADED_VALUE]]' , FieldExtension1 = 'ID' , FieldExtension2 = 'AITIA' , FieldExtension5 = 'EidosVlavis'  WHERE InternalName IN ('AitiaVlavis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ονομασία Θέσης'  WHERE InternalName IN ('OnomasiaThesis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Εκκρεμότητες'  WHERE InternalName IN ('Ekkremotites') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Προτεινόμενο Σημείο Εκσκαφης-Δήμος' , DataSourceTypeId = 4 , DataSource = '/VisitsGen/LookupMunicipalities' , FieldExtension1 = 'Id' , FieldExtension2 = 'Name'  WHERE InternalName IN ('ProteinomenoSimeio_Dimos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Προτεινόμενο Σημείο Εκσκαφης-Οδός' , DataSourceTypeId = 4 , DataSource = '/VisitsGen/LookupStreets/[[FIELD_VALUE]]?filter=[[CASCADED_VALUE]]' , FieldExtension1 = 'Id' , FieldExtension2 = 'Name' , FieldExtension5 = 'ProteinomenoSimeio_Dimos'  WHERE InternalName IN ('ProteinomenoSimeio_Odos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Προτεινόμενο Σημείο Εκσκαφης-Αριθμός'  WHERE InternalName IN ('ProteinomenoSimeio_Atihmos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Προτεινόμενο Σημείο Εκσκαφης-Γεωγραφικό Μήκος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=12; var lDecimals_[[FIELDNAME]]=9; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ProteinomenoSimeio_SyntetagmeniX') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Προτεινόμενο Σημείο Εκσκαφης-Γεωγραφικό Πλάτος' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=12; var lDecimals_[[FIELDNAME]]=9; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ProteinomenoSimeio_SyntetagmeniY') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Ονομασία Αντλιοστασίου' , DataSourceTypeId = 6 , DataSource = 'SELECT CONVERT(nvarchar(100), AntliostasioCode) + '' - '' + AntliostasioDescription AS DisplayText FROM Antliostasia WHERE AntliostasioIsActive=1' , FieldExtension1 = 'DisplayText' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('OnomasiaAntliostasiou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αποκατάστασης'  WHERE InternalName IN ('HmerominiaApokatastasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αποκατάστασης' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraApokatastasis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Παράπονο'  WHERE InternalName IN ('Parapono') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Εκτακτο Δείγμα'  WHERE InternalName IN ('EktaktoDeigma') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Υπολ.Χλωρίου με Lovipond (DPD)'  WHERE InternalName IN ('MetrisiCLMeLovipond') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Υπολ.Χλωρίου με φωτόμετρο Swan (DPD)'  WHERE InternalName IN ('MetrisiCLMeSwan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Υπολ.Χλωρίου με φωτόμετρο Lovipond (ταμπλέτες)'  WHERE InternalName IN ('MetrisiCLMeFotometroLovipond') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Απολυμαντικών με φωτόμετρο Swan (DPD - αντιδραστήρια Swan)'  WHERE InternalName IN ('MetrisiApolimantikonMeSwan') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Απολυμαντικών με φωτόμετρο Palintest (DPD - αντιδραστήρια Swan)'  WHERE InternalName IN ('MetrisiApolimantikonMePalintest') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Δειγματοληψίας'  WHERE InternalName IN ('HmerominiaDeigmatolipsias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Δειγματοληψίας' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraDeigmatolipsias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο Πεδίο' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('CLPedio') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο Μετατροπή' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('CLMetatropi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μέτρηση Υπ. Χλ. ppm πεδίο (Α)' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('MetrisiYpolCLPedioA') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διόρθωση λόγω Cl02 πεδίο (Β)' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('DiorthosiCL02PedioB') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο (Α-Β)' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('CL_A_B') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διοξείδιο του Χλωρίου' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('CLO2') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Δειγματολήπτης' , DataSourceTypeId = 6 , DataSource = 'SELECT CONVERT(nvarchar(100), PersonnelAM) + '' - '' + PersonnelName + '' '' + PersonnelSurName AS DisplayText FROM Personnel WHERE IsActive=1' , FieldExtension1 = 'DisplayText' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('Deigmatoliptis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Μετρητή'  WHERE InternalName IN ('ArithmosMetriti') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Επιπλέον Δείγμα #1'  WHERE InternalName IN ('EpipleonDeigma1') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο #1' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('EpipleonCL1') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Επιπλέον Δείγμα #2'  WHERE InternalName IN ('EpipleonDeigma2') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο #2' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('EpipleonCL2') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Επιπλέον Δείγμα #3'  WHERE InternalName IN ('EpipleonDeigma3') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο #3' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('EpipleonCL3') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Επιπλέον Δείγμα #4'  WHERE InternalName IN ('EpipleonDeigma4') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Χλώριο #4' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('EpipleonCL4') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textarea' , ControlTypeInViewForm = 'textarea' , ControlTypeInEditForm = 'textarea' , NameLocale1 = 'Ανάδραση Εργασιών από Tablet'  WHERE InternalName IN ('RemarksFromTablet') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Δήμος' , DataSourceTypeId = 4 , DataSource = '/VisitsGen/LookupMunicipalities' , FieldExtension1 = 'Id' , FieldExtension2 = 'Name'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Οδός' , DataSourceTypeId = 4 , DataSource = '/VisitsGen/LookupStreets/[[FIELD_VALUE]]?filter=[[CASCADED_VALUE]]' , FieldExtension1 = 'Id' , FieldExtension2 = 'Name' , FieldExtension5 = 'AddressMunicipality'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Αγωγού' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiAgogou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Μήκος Αγωγού'  WHERE InternalName IN ('AgogosMikos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Βανών' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=1; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ArithmosVanon') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ελεγχος Πίεσης (για Ειδική Παροχή)'  WHERE InternalName IN ('ElegxosPiesisGiaEidikiParoxi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Διατομή Αγωγού' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=3; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('AgogosDiatomi') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Ειδικής Παροχής' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiEidikisParoxis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Θέση Κατασκευής'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αναγγελίας'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αναγγελίας' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Αιτήματος Νέας Παροχής'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Ανατέθηκε σε Εργολαβία'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Εντολής Εργολάβου'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Εντολής Εργολάβου'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Σχόλια από BCC'  WHERE InternalName IN ('BCC_Remarks') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Επιφάνεια (τ.μ)' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=5; var lDecimals_[[FIELDNAME]]=2; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('EpifaneiaSqMtrs') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Είδος Πλακών '  WHERE InternalName IN ('EidosPlakon') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Πλακών' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=4; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ArithmosPlakon') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Τεμαχίων' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { return "";}' , DocumentReadyJSScript = 'var lMaxLength_[[FIELDNAME]]=4; var lDecimals_[[FIELDNAME]]=0; $( "#[[FIELDNAME]]" ).focus(function() { OnFocusNumericControl($(this),lMaxLength_[[FIELDNAME]]); }).keydown( function() { OnKeyDownNumericControl(event,$(this),lMaxLength_[[FIELDNAME]],lDecimals_[[FIELDNAME]]); }).change( function() { OnValueChangedNumericControl(event,$(this)); })'  WHERE InternalName IN ('ArithmosTemaxion') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Είδος Επέμβασης' , DataSourceTypeId = 2 , DataSource = 'Επισκευή;Αντικατάσταση'  WHERE InternalName IN ('EidosEpemvasisNeasParoxis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'checkbox' , ControlTypeInViewForm = 'checkbox' , ControlTypeInEditForm = 'checkbox' , NameLocale1 = 'Ρείθρο'  WHERE InternalName IN ('Reithro') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Οροφος'  WHERE InternalName IN ('Orofos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Πρόβλημα Πίεσης' , DefaultValue = 'Χαμηλή' , DataSourceTypeId = 2 , DataSource = 'Χαμηλή;Υψηλή'  WHERE InternalName IN ('ProblimaPiesis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'datetime' , ControlTypeInViewForm = 'datetime' , ControlTypeInEditForm = 'datetime' , NameLocale1 = 'Ημερομηνία Αναγγελίας'  WHERE InternalName IN ('HmerominiaAnagelias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'time' , ControlTypeInViewForm = 'time' , ControlTypeInEditForm = 'time' , NameLocale1 = 'Ωρα Αναγγελίας' , ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() { var isValid = true; var control = $("#[[FIELDNAME]]"); var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$"); isValid = patt.test(control.val()); if (!isValid) return "Σωστή μορφή ώρας HH:mm (24H)."; return "";}' , FieldExtension1 = 'HH:mm' , FieldExtension2 = '{0:HH:mm}'  WHERE InternalName IN ('OraAnagelias') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Ενέργειες Ελεγχου Πίεσης' , DefaultValue = 'Ιδια Μέσα' , DataSourceTypeId = 2 , DataSource = 'Ιδια Μέσα;Μανόμετρα'  WHERE InternalName IN ('EnergeiesProblimatosPiesis') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Αίτιο Προβλήματος' , DefaultValue = '1' , DataSourceTypeId = 6 , DataSource = 'SELECT AitioProblimatosId AS ValueInt, AitioProblimatosDescr AS DisplayText FROM AitiaProblimatonPiesis' , FieldExtension1 = 'ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('AitioProblimatosId') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'textbox' , ControlTypeInViewForm = 'textbox' , ControlTypeInEditForm = 'textbox' , NameLocale1 = 'Αριθμός Αιτήματος'  WHERE InternalName IN ('ArithmosAitimatos') AND Entity = 'Visits'
		UPDATE CategoriesFields SET SortOrder = 0 , LayoutOrder = 0 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInEditForm = 4 , ControlTypeInNewForm = 'dropdownlist' , ControlTypeInViewForm = 'dropdownlist' , ControlTypeInEditForm = 'dropdownlist' , NameLocale1 = 'Θέση Τέρματος' , DataSourceTypeId = 6 , DataSource = 'SELECT PositionId AS ValueInt, CONVERT(nvarchar(50), PositionCode) + '' - '' + PositionName AS DisplayText FROM Positions WHERE PositionType = 1 AND PositionIsActive = 1 ' , FieldExtension1 = ' ValueInt' , FieldExtension2 = 'DisplayText'  WHERE InternalName IN ('ThesiTermatos') AND Entity = 'Visits'

		UPDATE CategoriesFields SET ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() {
		  var isValid = true;
		  var control = $("#[[FIELDNAME]]");
		  var patt = new RegExp("^([01]?[0-9]|2[0-3]):[0-5][0-9]$");
		  isValid = patt.test(control.val());
		  if (!isValid)
			return "Σωστή μορφή ώρας HH:mm (24H).";
		  return "";
		}'
		WHERE InternalName IN ('ControlTime') AND Entity = 'Visits'

        UPDATE CategoriesFields SET ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() {
  var isValid = true;
  var control = $("#[[FIELDNAME]]");
  if (isNaN(control.val())) {
    isValid = false;
  }
  else {
    var valueInt = parseInt(control.val());
    if (valueInt < 0 || valueInt > 9) {
        isValid = false;
    }
  }
  if (!isValid)
    return "Το επιτρεπτό πεδίο τιμών είναι από 0 έως 9.";
  return "";
}'
            WHERE InternalName IN ('Apomonosi_ArithmosAtomonSynergeiou') AND Entity = 'Visits'


        UPDATE CategoriesFields SET ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() {
  var isValid = true;
  var control = $("#Epanafora_HmerominiaAfixis");
  var control2 = $("#Epanafora_HmerominiaAnaxorisis");
  var result = compareDates(control, control2);
  if (result > 0) {
      isValid = false;
  }
  if (!isValid)
    return "Η ημ/νία αναχώρησης πρέπει να είναι ίση ή μεταγενέστερη της ημ/νίας άφιξης.";
  return "";
}'
            WHERE InternalName IN ('Epanafora_HmerominiaAfixis') AND Entity = 'Visits'
        UPDATE CategoriesFields SET ValidationJSScript = 'function CustomValidate[[FIELDNAME]]() {
  return CustomValidateEpanafora_HmerominiaAfixis();
}'
            WHERE InternalName IN ('Epanafora_HmerominiaAnaxorisis') AND Entity = 'Visits'

        -- Task form E101
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'ArithmosAitimatos',
                    'AddressMunicipality',
                    'AddressOdos',
                    'AddressArithmos',
                    'AgogosDiametros',
                    'AgogosYliko',
                    'TopothetisiKatagrafikou',
                    'GnomateusiThesi',
                    'GnomateusiMikos',
                    'GnomateusiDiametros',
                    'GnomateusiYliko',
                    'Attachments',
                    'Remarks'
                )

        UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 305 , LayoutOrder = -1 , LayoutGroupId = 1 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΡΙΘΜΟΣ ΑΙΤΗΜΑΤΟΣ ΓΝΩΜΑΤΕΥΣΗΣ'  WHERE InternalName IN ('ArithmosAitimatos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΑΓΩΓΟΥ'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΑΓΩΓΟΥ'  WHERE InternalName IN ('AgogosYliko') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΛΕΓΧΟΣ ΠΙΕΣΗΣ (για νέα πυροσβεστική παροχή)'  WHERE InternalName IN ('TopothetisiKatagrafikou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΑΣΗ ΓΙΑ ΝΈΟ ΕΡΓΟ'  WHERE InternalName IN ('GnomateusiThesi') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΑΣΗ ΓΙΑ ΝΈΟ ΕΡΓΟ'  WHERE InternalName IN ('GnomateusiMikos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΑΣΗ ΓΙΑ ΝΈΟ ΕΡΓΟ'  WHERE InternalName IN ('GnomateusiDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΑΣΗ ΓΙΑ ΝΈΟ ΕΡΓΟ'  WHERE InternalName IN ('GnomateusiYliko') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E101')


        -- Task form E102
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'HmerominiaAnagelias',
					'OraAnagelias',
					'ProblimaPiesis',
                    'AddressMunicipality',
                    'AddressOdos',
                    'AddressArithmos',
					'Orofos',
					'ArithmosMetriti',
                    'SynergeioEpemvasis',
                    'Epemvasi_VardiaSynergeiou',
                    'ControlDate',
                    'ControlTime',
                    'Epemvasi_ArithmosAtomonSynergeiou',
                    'AitioProblimatosId',
                    'EnergeiesProblimatosPiesis',
					'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 301 , LayoutOrder = -1 , LayoutGroupId = 3 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ/ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 302 , LayoutOrder = -1 , LayoutGroupId = 3 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ/ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('OraAnagelias') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 305 , LayoutOrder = -1 , LayoutGroupId = 4 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΒΛΗΜΑ ΠΙΕΣΗΣ'  WHERE InternalName IN ('ProblimaPiesis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 340 , LayoutOrder = -1 , LayoutGroupId = 6 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΟΡΟΦΟΥ/ΜΕΤΡΗΤΗ'  WHERE InternalName IN ('Orofos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 6 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΟΡΟΦΟΥ/ΜΕΤΡΗΤΗ'  WHERE InternalName IN ('ArithmosMetriti') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΛΕΓΧΟΥ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlDate') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlTime') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΙΤΙΟ ΠΡΟΒΛΗΜΑΤΟΣ'  WHERE InternalName IN ('AitioProblimatosId') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ (Ελεγχος Πίεσης)'  WHERE InternalName IN ('EnergeiesProblimatosPiesis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1050 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E102')

        -- Task form E103
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'SynergeioEpemvasis',
                    'Oximata',
                    'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
                    'ControlDate',
                    'ControlTime',
                    'Porisma',
                    'Energeies',
                    'PositionOfGeotrisi',
                    'ResultsOfChemeio',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 450 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΝΕΡΓΕΙΟΥ / ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΝΕΡΓΕΙΟΥ / ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 550 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΝΕΡΓΕΙΟΥ / ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlDate') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 550 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΣΥΝΕΡΓΕΙΟΥ / ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlTime') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΟΧΗΜΑΤΑ'  WHERE InternalName IN ('Oximata') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΟΡΙΣΜΑ/ΕΝΕΡΓΕΙΕΣ'  WHERE InternalName IN ('Porisma') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΟΡΙΣΜΑ/ΕΝΕΡΓΕΙΕΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΓΕΩΤΡΗΣΗΣ'  WHERE InternalName IN ('PositionOfGeotrisi') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΤΕΛΕΣΜΑΤΑ ΧΗΜΕΙΟΥ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('ResultsOfChemeio') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΤΕΛΕΣΜΑΤΑ ΧΗΜΕΙΟΥ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E103')

        -- Task form E104, E105, E106
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'SynergeioEpemvasis',
                    'Oximata',
                    'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
                    'ControlDate',
                    'ControlTime',
                    'VanaDiametros',
                    'AgogosDiametros',
                    'MetritisDiametros',
                    'PyrosvestikiParoxiDiametros',
                    'ZoniPiesis',
					'SyntetagmenesVlavis',
					'Energeies',
                    'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E105'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104')
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E106'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΛΕΓΧΟΥ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΟΧΗΜΑΤΑ'  WHERE InternalName IN ('Oximata') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 650 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlDate') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΡΔΙΑΣ'  WHERE InternalName IN ('ControlTime') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('MetritisDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('PyrosvestikiParoxiDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('ZoniPiesis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΙΑΓΝΩΣΗ ΔΙΑΡΡΟΗΣ'  WHERE InternalName IN ('SyntetagmenesVlavis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E104' OR TaskCode = 'E105' OR TaskCode = 'E106')

        -- Task form E112
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'Eidopoiisi',
                    'VanaDiametros',
                    'AgogosDiametros',
                    'MetritisDiametros',
                    'EkplisiTermatos',
                    'PyrosvestikouGeranouDiametros',
                    'Zoni',
                    'HmerominiaApomonosis',
                    'OraApomonosis',
                    'Apomonosi_HmerominiaAfixis',
                    'Apomonosi_OraAfixis',
                    'Apomonosi_HmerominiaAnaxorisis',
                    'Apomonosi_OraAnaxorisis',
                    'Apomonosi_HmerominiaEpistrofis',
                    'Apomonosi_OraEpistrofis',
                    'Apomonosi_ArithmosAtomonSynergeiou',
                    'Apomonosi_VardiaSynergeiou',
                    'Apomonosi_ArirthosVanonPouXeiristikan',
                    'Apomonosi_KatastasiVanonPouXeiristikan',
                    'Apomonosi_ThesiVanonPouXeiristikan',
                    'EidosEpanaforas',
                    'HmerominiaEpanaforas',
                    'OraEpanaforas',
                    'Epanafora_HmerominiaAfixis',
                    'Epanafora_OraAfixis',
                    'Epanafora_HmerominiaAnaxorisis',
                    'Epanafora_OraAnaxorisis',
                    'Epanafora_HmerominiaEpistrofis',
                    'Epanafora_OraEpistrofis',
                    'Epanafora_ArithmosAtomonSynergeiou',
                    'Epanafora_VardiaSynergeiou',
                    'Epanafora_ArirthosVanonPouXeiristikan',
                    'Epanafora_KatastasiVanonPouXeiristikan',
                    'Epanafora_ThesiVanonPouXeiristikan',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Eidopoiisi') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('MetritisDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('EkplisiTermatos') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('PyrosvestikouGeranouDiametros') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΓΡΑΜΜΑΤΙΣΜΕΝΗ ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Zoni') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('HmerominiaApomonosis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('OraApomonosis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_HmerominiaAfixis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_OraAfixis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_HmerominiaAnaxorisis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_OraAnaxorisis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_HmerominiaEpistrofis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_OraEpistrofis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ'  WHERE InternalName IN ('Apomonosi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Apomonosi_ArirthosVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Apomonosi_KatastasiVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Apomonosi_ThesiVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1700 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('EidosEpanaforas') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1800 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1800 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1900 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_HmerominiaAfixis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1900 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_OraAfixis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2000 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_HmerominiaAnaxorisis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2000 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_OraAnaxorisis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2100 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_HmerominiaEpistrofis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2100 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_OraEpistrofis') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2200 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2400 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Epanafora_ArirthosVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2500 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Epanafora_KatastasiVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2600 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ - ΒΑΝΕΣ που χειρίστηκαν'  WHERE InternalName IN ('Epanafora_ThesiVanonPouXeiristikan') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2700 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E112')

        -- Task form E113
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiTermatos',
					'SimeioEkkenosis',
                    'HmerominiaEnarxisErgasion',
					'OraEnarxisErgasion',
					'SynergeioEpemvasis',
					'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
					'EparkeiaYlikon',
					'HmerominiaEpanaforas',
					'OraEpanaforas',
					'SynergeioEpanaforas',
					'Epanafora_VardiaSynergeiou',
					'Epanafora_ArithmosAtomonSynergeiou',
					'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 340 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΟΝΙΜΟΥ ΤΕΡΜΑΤΟΣ'  WHERE InternalName IN ('ThesiTermatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΟΝΙΜΟΥ ΤΕΡΜΑΤΟΣ'  WHERE InternalName IN ('SimeioEkkenosis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΝΑΡΞΗΣ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 410 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΝΑΡΞΗΣ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΚΠΛΥΣΕΩΝ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 510 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΚΠΛΥΣΕΩΝ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 520 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΚΠΛΥΣΕΩΝ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 530 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΡΚΕΙΑ ΥΛΙΚΩΝ'  WHERE InternalName IN ('EparkeiaYlikon') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 550 , LayoutOrder = 0 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 560 , LayoutOrder = 1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('SynergeioEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 610 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 620 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E113')

        -- Task form E114, E115, E116, E119
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
                    'OnomaVanas',
                    'ThesiVanas',
                    'VanaDiametros',
                    'KatastasiVanas',
					'SynergeioEpemvasis',
                    'Epemvasi_VardiaSynergeiou',
                    'Epemvasi_ArithmosAtomonSynergeiou',
                    'Energeies',
                    'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E115'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114')
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E116'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114')
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E119'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('OnomaVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('KatastasiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E114' OR  TaskCode = 'E115' OR  TaskCode = 'E116' OR  TaskCode = 'E119')


		-- Task form E117
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
                    'OnomaVanas',
                    'ThesiVanas',
                    'VanaDiametros',
                    'KatastasiVanas',
					'SynergeioEpemvasis',
                    'Epemvasi_VardiaSynergeiou',
                    'Epemvasi_ArithmosAtomonSynergeiou',
					'KalymaEidos',
					'KalymaDiastaseis',
                    'Energeies',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('OnomaVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('KatastasiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 0 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΚΑΛΥΜΜΑ'  WHERE InternalName IN ('KalymaEidos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΚΑΛΥΜΜΑ'  WHERE InternalName IN ('KalymaDiastaseis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E117')

		-- Task form E118
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
                    'OnomaVanas',
                    'ThesiVanas',
                    'VanaDiametros',
                    'KatastasiVanas',
					'SynergeioEpemvasis',
                    'Epemvasi_VardiaSynergeiou',
                    'Epemvasi_ArithmosAtomonSynergeiou',
					'FreatioEidos',
					'FreatioDiastaseis',
                    'Energeies',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('OnomaVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΒΑΝΑΣ (που φανερώθηκε)'  WHERE InternalName IN ('KatastasiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΦΡΕΑΤΙΟ'  WHERE InternalName IN ('FreatioEidos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΦΡΕΑΤΙΟ'  WHERE InternalName IN ('FreatioDiastaseis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E118')

		-- Task form E120 - E121
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
                    'OnomaVanas',
                    'ThesiVanas',
                    'VanaDiametros',
                    'KatastasiVanas',
					'EidosProblimatos',
					'EidosEpemvasis',
					'SynergeioEpemvasis',
                    'Epemvasi_VardiaSynergeiou',
                    'Epemvasi_ArithmosAtomonSynergeiou',
					'HmerominiaEpanaforas',
					'OraEpanaforas',
					'SynergeioEpanaforas',
					'Epanafora_VardiaSynergeiou',
					'Epanafora_ArithmosAtomonSynergeiou',
                    'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E121'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('OnomaVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('KatastasiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1050 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('EidosProblimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1050 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΜΠΛΕ ΒΑΝΑΣ'  WHERE InternalName IN ('EidosEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('SynergeioEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1700 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1800 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1900 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E120' OR TaskCode = 'E121')

		-- Task form E122-E124
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
					'OnomaDexamenis',
					'ThesiDexamenis',
					'ThalamosDexamenis',
					'SimeioEkkenosis',
					'ArithmosAntlion',
					'MegaliMikriAntlia',
					'PRV_Xeirismos',
					'EidosTermatos',
					'EparkeiaYlikon',
					'SynergeioEpemvasis',
					'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
					'MAP',
					'HmerominiaEpanaforas',
					'OraEpanaforas',
					'SynergeioEpanaforas',
					'Epanafora_VardiaSynergeiou',
					'Epanafora_ArithmosAtomonSynergeiou',
					'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E124'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('OnomaDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('ThesiDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('ThalamosDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('SimeioEkkenosis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ ΑΝΤΛΙΩΝ (Booster)'  WHERE InternalName IN ('ArithmosAntlion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ ΑΝΤΛΙΩΝ (Booster)'  WHERE InternalName IN ('MegaliMikriAntlia') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ PRV'  WHERE InternalName IN ('PRV_Xeirismos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΤΕΡΜΑΤΟΣ - ΕΠΑΡΚΕΙΑ ΥΛΙΚΩΝ'  WHERE InternalName IN ('EidosTermatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΤΕΡΜΑΤΟΣ - ΕΠΑΡΚΕΙΑ ΥΛΙΚΩΝ'  WHERE InternalName IN ('EparkeiaYlikon') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1700 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1800 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1900 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('MAP') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2000 , LayoutOrder = 0 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2000 , LayoutOrder = 1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2100 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('SynergeioEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2200 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2300 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2400 , LayoutOrder = -1 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E122' OR TaskCode = 'E124')

	    -- Task form E123
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
					'OnomaDexamenis',
					'ThesiDexamenis',
					'ThalamosDexamenis',
					'SimeioEkkenosis',
					'ArithmosAntlion',
					'MegaliMikriAntlia',
					'PRV_Xeirismos',
					'EidosProblimatos',
					'EidosEpemvasis',
					'EidosTermatos',
					'SynergeioEpemvasis',
					'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
					'HmerominiaEpanaforas',
					'OraEpanaforas',
					'SynergeioEpanaforas',
					'Epanafora_VardiaSynergeiou',
					'Epanafora_ArithmosAtomonSynergeiou',
					'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('OnomaDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('ThesiDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('ThalamosDexamenis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΞΑΜΕΝΗΣ'  WHERE InternalName IN ('SimeioEkkenosis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ ΑΝΤΛΙΩΝ (Booster)'  WHERE InternalName IN ('ArithmosAntlion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ ΑΝΤΛΙΩΝ (Booster)'  WHERE InternalName IN ('MegaliMikriAntlia') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΧΕΙΡΙΣΜΟΣ PRV'  WHERE InternalName IN ('PRV_Xeirismos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΠΡΟΒΛΗΜΑΤΟΣ-ΕΠΕΜΒΑΣΗΣ-ΤΕΡΜΑΤΟΣ'  WHERE InternalName IN ('EidosProblimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΠΡΟΒΛΗΜΑΤΟΣ-ΕΠΕΜΒΑΣΗΣ-ΤΕΡΜΑΤΟΣ'  WHERE InternalName IN ('EidosEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΠΡΟΒΛΗΜΑΤΟΣ-ΕΠΕΜΒΑΣΗΣ-ΤΕΡΜΑΤΟΣ'  WHERE InternalName IN ('EidosTermatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1800 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1900 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2000 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2200 , LayoutOrder = 0 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2200 , LayoutOrder = 1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2300 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('SynergeioEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2400 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2500 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΕΠΑΝΑΦΟΡΑΣ'  WHERE InternalName IN ('Epanafora_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 2600 , LayoutOrder = -1 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E123')

		-- Task form E125, E126, E127, E128
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
                    'OnomaPRV',
                    'ThesiPRV',
                    'DiametrosPRV',
                    'KatastasiPRV',
					'SynergeioEpemvasis',
                    'PRVVardiaSynergeiou',
                    'PRVArithmosAtomonSynergeiou',
                    'Energeies',
                    'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E126'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125')
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E127'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125')
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E128'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125')

			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΑΡΞΗ-ΛΗΞΗ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ PRV'  WHERE InternalName IN ('OnomaPRV') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ PRV'  WHERE InternalName IN ('ThesiPRV') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ PRV'  WHERE InternalName IN ('DiametrosPRV') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ PRV'  WHERE InternalName IN ('KatastasiPRV') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ PRV'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ PRV'  WHERE InternalName IN ('PRVVardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ PRV'  WHERE InternalName IN ('PRVArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')
			UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E125' OR  TaskCode = 'E126' OR  TaskCode = 'E127' OR  TaskCode = 'E128')

		-- Task form E301
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaApomonosis',
					'OraApomonosis',
					'HmerominiaEpanaforas',
					'OraEpanaforas',
					'Ergolavia',
					'Idiotiko',
					'TroposEntopismou',
					'EidosVlavis',
					'AitiaVlavis',
					'Epemvasi_VardiaSynergeiou',
					'SynergeioEpemvasis',
					'Oximata',
					'Remarks',
					'RemarksFromTablet'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4 ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3 ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('HmerominiaApomonosis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΜΟΝΩΣΗ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('OraApomonosis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('HmerominiaEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΑΝΑΦΟΡΑ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('OraEpanaforas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΡΓΟΛΑΒΙΑ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Ergolavia') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΙΔΙΩΤΙΚΟ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Idiotiko') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΤΡΟΠΟΣ ΕΝΤΟΠΙΣΜΟΥ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('TroposEntopismou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 0 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ-ΑΙΤΙΑ ΒΛΑΒΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('EidosVlavis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = 1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ-ΑΙΤΙΑ ΒΛΑΒΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('AitiaVlavis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 1  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Oximata') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = -1 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = -1 , LayoutGroupId = 90 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1 , NameLocale9 = 'ΑΝΑΔΡΑΣΗ ΕΡΓΑΣΙΩΝ ΑΠΌ TABLET' ,  IsMandatoryInNewForm = 0 , IsMandatoryInEditForm = 0  WHERE InternalName IN ('RemarksFromTablet') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E301')


		-- Task form E700
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'SynergeioEpemvasis',
					'Attachments'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΨΗ ΑΠΟΤΕΛΕΣΜΑΤΩΝ ΚΑΤΑΓΡΑΦΙΚΩΝ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E700')

		-- Task form E701
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'OnomasiaThesis',
					'HmerominiaEpemvasis',
					'OraEpemvasis',
					'SynergeioEpemvasis',
					'Energeies',
					'Ekkremotites'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΟΝΟΜΑΣΙΑ ΘΕΣΗΣ'  WHERE InternalName IN ('OnomasiaThesis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('HmerominiaEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('OraEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΕΚΚΡΕΜΟΤΗΤΕΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΕΚΚΡΕΜΟΤΗΤΕΣ'  WHERE InternalName IN ('Ekkremotites') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E701')

		-- Task form E800
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'HmerominiaEpemvasis',
					'OraEpemvasis',
					'SynergeioEpemvasis',
					'Porisma',
					'ProteinomenoSimeio_Dimos',
					'ProteinomenoSimeio_Odos',
					'ProteinomenoSimeio_Atihmos',
					'ProteinomenoSimeio_SyntetagmeniX',
					'ProteinomenoSimeio_SyntetagmeniY'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('HmerominiaEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('OraEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΟΡΙΣΜΑ'  WHERE InternalName IN ('Porisma') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟ ΣΗΜΕΙΟ ΕΚΣΚΑΦΗΣ'  WHERE InternalName IN ('ProteinomenoSimeio_Dimos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟ ΣΗΜΕΙΟ ΕΚΣΚΑΦΗΣ'  WHERE InternalName IN ('ProteinomenoSimeio_Odos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟ ΣΗΜΕΙΟ ΕΚΣΚΑΦΗΣ'  WHERE InternalName IN ('ProteinomenoSimeio_Atihmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟ ΣΗΜΕΙΟ ΕΚΣΚΑΦΗΣ'  WHERE InternalName IN ('ProteinomenoSimeio_SyntetagmeniX') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟ ΣΗΜΕΙΟ ΕΚΣΚΑΦΗΣ'  WHERE InternalName IN ('ProteinomenoSimeio_SyntetagmeniY') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E800')

		-- Task form E801
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    --'State',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'OnomasiaAntliostasiou',
					'HmerominiaEpemvasis',
					'OraEpemvasis',
					'SynergeioEpemvasis',
					'HmerominiaApokatastasis',
					'OraApokatastasis',
					'Energeies'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΝΤΛΙΟΣΤΑΣΙΟ'  WHERE InternalName IN ('OnomasiaAntliostasiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('HmerominiaEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('OraEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΚΑΤΑΣΤΑΣΗ'  WHERE InternalName IN ('HmerominiaApokatastasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΠΟΚΑΤΑΣΤΑΣΗ'  WHERE InternalName IN ('OraApokatastasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E801')

		-- Task form E802-E803
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'OnomasiaAntliostasiou',
					'HmerominiaEpemvasis',
					'OraEpemvasis',
					'SynergeioEpemvasis',
					'Porisma'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E803'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΑΝΤΛΙΟΣΤΑΣΙΟ'  WHERE InternalName IN ('OnomasiaAntliostasiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('HmerominiaEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('OraEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΕΜΒΑΣΗ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΟΡΙΣΜΑ'  WHERE InternalName IN ('Porisma') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E802' OR  TaskCode = 'E803')

		-- Task form E1001
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'Parapono',
					'EktaktoDeigma',
					'MetrisiCLMeLovipond',
					'MetrisiCLMeSwan',
					'MetrisiCLMeFotometroLovipond',
					'MetrisiApolimantikonMeSwan',
					'MetrisiApolimantikonMePalintest',
					'HmerominiaDeigmatolipsias',
					'OraDeigmatolipsias',
					'CLPedio',
					'CLMetatropi',
					'MetrisiYpolCLPedioA',
					'DiorthosiCL02PedioB',
					'CL_A_B',
					'CLO2',
					'Deigmatoliptis',
					'ArithmosMetriti',
					'EpipleonDeigma1',
					'EpipleonCL1',
					'EpipleonDeigma2',
					'EpipleonCL2',
					'EpipleonDeigma3',
					'EpipleonCL3',
					'EpipleonDeigma4',
					'EpipleonCL4',
					'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΠΟΝΟ/ΕΚΤΑΚΤΟ ΔΕΙΓΜΑ'  WHERE InternalName IN ('Parapono') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 400 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΠΟΝΟ/ΕΚΤΑΚΤΟ ΔΕΙΓΜΑ'  WHERE InternalName IN ('EktaktoDeigma') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 500 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΜΕΤΡΗΣΕΙΣ ΧΛΩΡΙΟΥ'  WHERE InternalName IN ('MetrisiCLMeLovipond') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 600 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΜΕΤΡΗΣΕΙΣ ΧΛΩΡΙΟΥ'  WHERE InternalName IN ('MetrisiCLMeSwan') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 700 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΜΕΤΡΗΣΕΙΣ ΧΛΩΡΙΟΥ'  WHERE InternalName IN ('MetrisiCLMeFotometroLovipond') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 800 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΜΕΤΡΗΣΕΙΣ ΧΛΩΡΙΟΥ'  WHERE InternalName IN ('MetrisiApolimantikonMeSwan') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 900 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΜΕΤΡΗΣΕΙΣ ΧΛΩΡΙΟΥ'  WHERE InternalName IN ('MetrisiApolimantikonMePalintest') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 0 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΙΓΜΑΤΟΛΗΨΙΑΣ'  WHERE InternalName IN ('HmerominiaDeigmatolipsias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΙΓΜΑΤΟΛΗΨΙΑΣ'  WHERE InternalName IN ('OraDeigmatolipsias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 2 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΙΓΜΑΤΟΛΗΨΙΑΣ'  WHERE InternalName IN ('CLPedio') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1000 , LayoutOrder = 3 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΕΙΓΜΑΤΟΛΗΨΙΑΣ'  WHERE InternalName IN ('CLMetatropi') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 0 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΆΛΛΕΣ ΜΕΤΡΗΣΕΙΣ'  WHERE InternalName IN ('MetrisiYpolCLPedioA') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΆΛΛΕΣ ΜΕΤΡΗΣΕΙΣ'  WHERE InternalName IN ('DiorthosiCL02PedioB') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 2 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΆΛΛΕΣ ΜΕΤΡΗΣΕΙΣ'  WHERE InternalName IN ('CL_A_B') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1100 , LayoutOrder = 3 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΆΛΛΕΣ ΜΕΤΡΗΣΕΙΣ'  WHERE InternalName IN ('CLO2') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = 0 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΕΙΓΜΑΤΟΛΗΠΤΗΣ/ΑΡΙΘΜΟΣ ΜΕΤΡΗΤΗ'  WHERE InternalName IN ('Deigmatoliptis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1200 , LayoutOrder = 1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΔΕΙΓΜΑΤΟΛΗΠΤΗΣ/ΑΡΙΘΜΟΣ ΜΕΤΡΗΤΗ'  WHERE InternalName IN ('ArithmosMetriti') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = 0 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #1'  WHERE InternalName IN ('EpipleonDeigma1') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1300 , LayoutOrder = 1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #1'  WHERE InternalName IN ('EpipleonCL1') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 0 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #2'  WHERE InternalName IN ('EpipleonDeigma2') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1400 , LayoutOrder = 1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #2'  WHERE InternalName IN ('EpipleonCL2') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = 0 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #3'  WHERE InternalName IN ('EpipleonDeigma3') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1500 , LayoutOrder = 1 , LayoutGroupId = 80 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #3'  WHERE InternalName IN ('EpipleonCL3') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = 0 , LayoutGroupId = 90 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #4'  WHERE InternalName IN ('EpipleonDeigma4') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1600 , LayoutOrder = 1 , LayoutGroupId = 90 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΠΛΕΟΝ ΔΕΙΓΜΑ #4'  WHERE InternalName IN ('EpipleonCL4') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 1700 , LayoutOrder = -1 , LayoutGroupId = 100 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E1001')

	    -- Task form Y010, Y012, Y015, Y021, Y022, Y023, Y031, Y032, Y033, Y034, Y035, Y036, Y037, Y038
		-- Y040, Y043, Y044, Y057, T040

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
                    'HmerominiaEnarxisErgasion',
                    'OraEnarxisErgasion',
                    'HmerominiaLixisErgasion',
                    'OraLixisErgasion',
					'SynergeioEpemvasis',
					'Oximata',
					'Epemvasi_VardiaSynergeiou',
					'Epemvasi_ArithmosAtomonSynergeiou',
                    'Energeies',
                    'Remarks'
                )

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y012'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y015'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y021'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y022'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y023'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y031'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y032'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y033'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y034'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y035'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y036'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y037'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y038'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y040'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y043'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y044'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y057'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'T040'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFieldsPerTaskType
			WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('HmerominiaEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('OraEnarxisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('HmerominiaLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('OraLixisErgasion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 430 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('SynergeioEpemvasis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 440 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Oximata') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 450 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_VardiaSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 460 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΥΝΕΡΓΕΙΟ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Epemvasi_ArithmosAtomonSynergeiou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 470 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Energeies') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 480 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΝΕΡΓΕΙΕΣ/ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'Y010' OR  TaskCode = 'Y012' OR  TaskCode = 'Y015' OR  TaskCode = 'Y021' OR  TaskCode = 'Y022' OR  TaskCode = 'Y023' OR  TaskCode = 'Y031' OR  TaskCode = 'Y032' OR  TaskCode = 'Y033' OR  TaskCode = 'Y034' OR  TaskCode = 'Y035' OR  TaskCode = 'Y036' OR  TaskCode = 'Y037' OR  TaskCode = 'Y038' OR  TaskCode = 'Y040' OR  TaskCode = 'Y043' OR  TaskCode = 'Y044' OR  TaskCode = 'Y057' OR  TaskCode = 'T040')

	-- Task form E107, 19.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiAgogou',
					'AgogosDiametros',
					'AgogosYliko',
					'AgogosMikos',
					'Attachments',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΑΓΩΓΟΥ'  WHERE InternalName IN ('ThesiAgogou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟΣ ΑΓΩΓΟΣ'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟΣ ΑΓΩΓΟΣ'  WHERE InternalName IN ('AgogosYliko') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΟΣ ΑΓΩΓΟΣ'  WHERE InternalName IN ('AgogosMikos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 360 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΡΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E107')

		-- Task form E108, 19.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiVanas',
					'ArithmosVanon',
					'VanaDiametros',
					'Attachments',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΒΑΝΑΣ'  WHERE InternalName IN ('ThesiVanas') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΕΣ ΒΑΝΕΣ'  WHERE InternalName IN ('ArithmosVanon') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΕΣ ΒΑΝΕΣ'  WHERE InternalName IN ('VanaDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 360 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΡΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E108')
		f
		-- Task form E109, 19.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiEidikisParoxis',
					'ElegxosPiesisGiaEidikiParoxi',
					'TopothetisiKatagrafikou',
					'AgogosDiatomi',
					'AgogosDiametros',
					'Attachments',
                    'Remarks'
                )

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΕΙΔΙΚΗΣ ΠΑΡΟΧΗΣ'  WHERE InternalName IN ('ThesiEidikisParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΗ ΕΙΔΙΚΗ ΠΑΡΟΧΗ'  WHERE InternalName IN ('ElegxosPiesisGiaEidikiParoxi') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΡΟΤΕΙΝΟΜΕΝΗ ΕΙΔΙΚΗ ΠΑΡΟΧΗ'  WHERE InternalName IN ('TopothetisiKatagrafikou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΥΠΑΡΧΟΝΤΟΣ ΑΓΩΓΟΥ'  WHERE InternalName IN ('AgogosDiatomi') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 340 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΥΠΑΡΧΟΝΤΟΣ ΑΓΩΓΟΥ'  WHERE InternalName IN ('AgogosDiametros') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 350 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 360 , LayoutOrder = -1 , LayoutGroupId = 70 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΡΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E109')

		-- Task form E203-E204-E212-E213-E214-E215-E216-E217-E218-E219-E220, 20.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiKataskeyisNeasParoxis',
					'BCC_HmerominiaAnagelias',
					'BCC_OraAnagelias',
					'BCC_ArithmosAitimatos',
					'BCC_ErgolaviaNeasParoxis',
					'BCC_ArithmosEntolisErgolavou',
					'BCC_HmerominiaEntolis',
					'Remarks',
					'Attachments')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E212'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E213'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E214'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E215'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E216'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E217'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E218'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E219'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E220'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 280 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204' OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E203' OR  TaskCode = 'E204'  OR  TaskCode = 'E212' OR  TaskCode = 'E213' OR  TaskCode = 'E214' OR  TaskCode = 'E215' OR  TaskCode = 'E216' OR  TaskCode = 'E217' OR  TaskCode = 'E218' OR  TaskCode = 'E219' OR  TaskCode = 'E220')

		-- Task form E205-E207-E210, 20.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiKataskeyisNeasParoxis',
					'BCC_HmerominiaAnagelias',
					'BCC_OraAnagelias',
					'BCC_ArithmosAitimatos',
					'BCC_ErgolaviaNeasParoxis',
					'BCC_ArithmosEntolisErgolavou',
					'BCC_HmerominiaEntolis',
					'EpifaneiaSqMtrs',
					'Remarks',
					'Attachments')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E207'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E210'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			   FROM CategoriesFieldsPerTaskType
			  WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 280 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΦΑΝΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('EpifaneiaSqMtrs') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E205' OR  TaskCode = 'E207' OR  TaskCode = 'E210')


		-- Task form E206-E211, 20.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiKataskeyisNeasParoxis',
					'BCC_HmerominiaAnagelias',
					'BCC_OraAnagelias',
					'BCC_ArithmosAitimatos',
					'BCC_ErgolaviaNeasParoxis',
					'BCC_ArithmosEntolisErgolavou',
					'BCC_HmerominiaEntolis',
					'EidosPlakon',
					'ArithmosPlakon',
					'Reithro',
					'Remarks',
					'Attachments')

		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			 SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E211'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			 FROM CategoriesFieldsPerTaskType
			 WHERE Entity = 'Visits' AND TaskType = (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 280 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 300 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('EidosPlakon') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('ArithmosPlakon') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 320 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΙΔΟΣ ΕΠΕΜΒΑΣΗΣ'  WHERE InternalName IN ('Reithro') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 50 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 340 , LayoutOrder = -1 , LayoutGroupId = 60 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΕΠΙΣΥΝΑΠΤΟΜΕΝΑ ΑΡΧΕΙΑ'  WHERE InternalName IN ('Attachments') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E206' OR  TaskCode = 'E211')


	    -- Task form E208, 20.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiKataskeyisNeasParoxis',
					'BCC_HmerominiaAnagelias',
					'BCC_OraAnagelias',
					'BCC_ArithmosAitimatos',
					'BCC_ErgolaviaNeasParoxis',
					'BCC_ArithmosEntolisErgolavou',
					'BCC_HmerominiaEntolis',
					'ArithmosTemaxion',
					'Remarks')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 280 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ArithmosTemaxion') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E208')

		-- Task form E209, 20.07.2016
		INSERT INTO CategoriesFieldsPerTaskType(CategoryId, FieldId, InternalName, Entity, TaskType, FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated)
			SELECT CategoryId, FieldId, InternalName, Entity, (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209'), FieldStateInNewForm, FieldStateInViewForm, FieldStateInEditForm, IsMandatoryInNewForm, IsMandatoryInEditForm, RowStatus, RowInserted, RowLastUpdated
			FROM CategoriesFields
			WHERE Entity = 'Visits' AND
				InternalName IN (
                    --'Task_Id',
                    'Task_Description',
                    --'Comments',
                    'Incident_Id',
                    'TaskTypeId',
					'Status',
					'AddressMunicipality',
					'AddressOdos',
					'AddressArithmos',
					'ThesiKataskeyisNeasParoxis',
					'BCC_HmerominiaAnagelias',
					'BCC_OraAnagelias',
					'BCC_ArithmosAitimatos',
					'BCC_ErgolaviaNeasParoxis',
					'BCC_ArithmosEntolisErgolavou',
					'BCC_HmerominiaEntolis',
					'EidosEpemvasisNeasParoxis',
					'Remarks')

		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 100 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 1 , FieldStateInViewForm = 1 , FieldStateInEditForm = 1  WHERE InternalName IN ('Task_Description') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 4 , FieldStateInViewForm = 4 , FieldStateInEditForm = 4  WHERE InternalName IN ('Incident_Id') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 0 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 3 , FieldStateInViewForm = 3 , FieldStateInEditForm = 3  WHERE InternalName IN ('TaskTypeId') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 200 , LayoutOrder = -1 , LayoutGroupId = 0 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2  WHERE InternalName IN ('Status') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 210 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressMunicipality') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 220 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressOdos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 230 , LayoutOrder = -1 , LayoutGroupId = 5 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΔΙΕΥΘΥΝΣΗΣ'  WHERE InternalName IN ('AddressArithmos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 240 , LayoutOrder = -1 , LayoutGroupId = 10 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΘΕΣΗ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('ThesiKataskeyisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 0 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_HmerominiaAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 250 , LayoutOrder = 1 , LayoutGroupId = 20 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΗΜΕΡΟΜΗΝΙΑ-ΩΡΑ ΑΝΑΓΓΕΛΙΑΣ'  WHERE InternalName IN ('BCC_OraAnagelias') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 260 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosAitimatos') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 270 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ErgolaviaNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 280 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_ArithmosEntolisErgolavou') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 290 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('BCC_HmerominiaEntolis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 310 , LayoutOrder = -1 , LayoutGroupId = 30 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΣΤΟΙΧΕΙΑ ΚΑΤΑΣΚΕΥΗΣ'  WHERE InternalName IN ('EidosEpemvasisNeasParoxis') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')
		UPDATE CategoriesFieldsPerTaskType SET SortOrder = 330 , LayoutOrder = -1 , LayoutGroupId = 40 , FieldStateInNewForm = 2 , FieldStateInViewForm = 1 , FieldStateInEditForm = 2 , NameLocale9 = 'ΠΑΡΑΤΗΡΗΣΕΙΣ'  WHERE InternalName IN ('Remarks') AND Entity = 'Visits' AND TaskType IN (SELECT TaskTypeId FROM TaskTypes WHERE TaskCode = 'E209')

END

