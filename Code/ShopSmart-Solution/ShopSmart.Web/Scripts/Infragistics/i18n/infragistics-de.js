/*!
* Infragistics.Web.ClientUI data source localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.DataSourceLocale) {
	$.ig.DataSourceLocale = {};

	$.extend($.ig.DataSourceLocale, {

		locale: {
			invalidDataSource: "Die angegebene Datenquelle ist ungültig. Es kann ein Skalar sein.",
			unknownDataSource: "Der Datenquellentyp kann nicht bestimmt werden. Bitte angeben, ob es sich um JSON- oder XML-Daten handelt.",
			errorParsingArrays: "Bei der Analyse der Arraydaten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			errorParsingJson: "Bei der Analyse der JSON-Daten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			errorParsingXml: "Bei der Analyse der XML-Daten und der Anwendung des definierten Datenschemas ist ein Fehler aufgetreten: ",
			errorParsingHtmlTable: "Beim Extrahieren der Daten aus der HTML-Tabelle und der Anwendung des Schemas ist ein Fehler aufgetreten: ",
			errorExpectedTbodyParameter: "tbody oder table wurde als Parameter erwartet.",
			errorTableWithIdNotFound: "Die HTML-Tabelle mit der folgenden ID wurde nicht gefunden: ",
			errorParsingHtmlTableNoSchema: "Bei der Analyse der Tabelle DOM ist ein Fehler aufgetreten: ",
			errorParsingJsonNoSchema: "Bei der Analyse/Auswertung der JSON-Zeichenfolge ist ein Fehler aufgetreten: ",
			errorParsingXmlNoSchema: "Bei der Analyse der XML-Zeichenfolge ist ein Fehler aufgetreten: ",
			errorXmlSourceWithoutSchema: "Die angegebene Datenquelle ist ein XML-Dokument, aber es gibt kein definiertes Datenschema ($.IgDataSchema). ",
			errorUnrecognizedFilterCondition: " Die angegebene Filterbedingung wurde nicht erkannt: ",
			errorRemoteRequest: "Die Remoteanforderung zum Abrufen von Daten ist fehlgeschlagen: ",
			errorSchemaMismatch: "Die Eingabedaten stimmen nicht mit dem Schema überein, das folgende Feld konnte nicht zugeordnet werden: ",
			errorSchemaFieldCountMismatch: "Die Eingabedaten stimmen in Bezug auf die Anzahl Felder nicht mit dem Schema überein. ",
			errorUnrecognizedResponseType: "Der Antworttyp wurde entweder nicht korrekt eingestellt oder konnte nicht automatisch erkannt werden. Bitte settings.responseDataType und/oder settings.responseContentType einstellen.",
			hierarchicalTablesNotSupported: "Tabellen werden nicht für HierarchicalSchema unterstützt.",
			cannotBuildTemplate: "Die jQuery-Vorlage konnte nicht erstellt werden. Es gibt keine Datensätze in der Datenquelle und keine definierten Spalten.",
			unrecognizedCondition: "Nicht erkannte Filterbedingung im folgenden Ausdruck: ",
			fieldMismatch: "Der folgende Ausdruck enthält ein ungültiges Feld oder eine ungültige Filterbedingung: ",
			noSortingFields: "Es wurden keine Felder angegeben. Beim Aufrufen von sort() muss mindestens ein Feld zum Sortieren angegeben werden.",
			filteringNoSchema: "Es wurden kein Schema / Felder angegeben. Es muss ein Schema mit Felddefinitionen und Feldtypen angegeben werden, um die Datenquelle filtern zu können."
		}
	});

}

/*!
* Infragistics.Web.ClientUI common DV widget localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.Chart) {
	$.ig.Chart = {};

	$.extend($.ig.Chart, {

		locale: {
			unsupportedBrowser: "Der aktuelle Browser unterstützt HTML5 Canvas Element nicht. <br/>Führen Sie ein Upgrade auf eine der folgenden Versionen durch:",
			currentBrowser: "Aktueller Browser: {0}",
			ie9: "Microsoft Internet Explorer V 9+",
			chrome8: "Google Chrome V 8+",
			firefox36: "Mozilla Firefox V 3.6+",
			safari5: "Apple Safari V 5+",
			opera11: "Opera V 11+",
			ieDownload: "http://www.microsoft.com/windows/internet-explorer/default.aspx",
			operaDownload: "http://www.opera.com/download/",
			chromeDownload: "http://www.google.com/chrome",
			firefoxDownload: "http://www.mozilla.com/",
			safariDownload: "http://www.apple.com/safari/download/",
			seriesName: "muss beim Einstellen von Optionen die Option Datenreihenname angeben.",
			axisName: "muss beim Einstellen von Optionen die Option Achsenname angeben.",
			close: "Schließen",
			overview: "Übersicht",
			zoomOut: "Verkleinern",
			zoomIn: "Vergrößern",
			resetZoom: "Zoom zurücksetzen"
		}
	});

}

/*!
* Infragistics.Web.ClientUI shared localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*jQuery must be defined before this. If it is not the $ variable is created*/
$ = $ || {};

$.ig = $.ig || {};

if (!$.ig.SharedLocale) {
	$.ig.SharedLocale = {};

	$.extend($.ig.SharedLocale, {

		locale: {
			popoverOptionChangeNotSupported: "Die �nderung der folgenden Option nach der Initialisierung von igPopover wird nicht unterst�tzt:"
		}
	});

}

/*!
* Infragistics.Web.ClientUI templating localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.Templating) {
	$.ig.Templating = {};

	$.extend($.ig.Templating, {
		locale: {
			undefinedArgument: 'Beim Abrufen der Datenquellen-Eigenschaft ist ein Fehler aufgetreten: '
		}
	});
}

/*!
* Infragistics.Web.ClientUI Combo localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global $ */
$.ig = $.ig || {};

if (!$.ig.Combo) {
	$.ig.Combo = {
		locale: {
			noMatchFoundText: 'Keine Ergebnisse',
			dropDownButtonTitle: 'Dropdown anzeigen',
			clearButtonTitle: 'Wert löschen'
		}
	};
}

/*!
* Infragistics.Web.ClientUI Dialog localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global $ */
$.ig = $.ig || {};

if (!$.ig.Dialog) {
	$.ig.Dialog = {
		locale: {
			closeButtonTitle: "Schließen",
			minimizeButtonTitle: "Minimieren",
			maximizeButtonTitle: "Maximieren",
			pinButtonTitle: "Anheften",
			unpinButtonTitle: "Lösen",
			restoreButtonTitle: "Wiederherstellen"
		}
	};
}

/*!
* Infragistics.Web.ClientUI Editors localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global $ */
$.ig = $.ig || {};

if (!$.ig.Editor) {
	$.ig.Editor = {
		locale: {
			spinUpperTitle: 'Erhöhen',
			spinLowerTitle: 'Verringern',
			buttonTitle: 'Liste anzeigen',
			clearTitle: 'Wert löschen',
			datePickerButtonTitle: 'Kalender anzeigen'
		}
	};
}

/*!
* Infragistics.Web.ClientUI Grid localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.Grid) {
	$.ig.Grid = {};

	$.extend($.ig.Grid, {

		locale: {
			noSuchWidget: "Kein solches Widget geladen: ",
			autoGenerateColumnsNoRecords: "autoGenerateColumns ist aktiviert, aber es gibt keine Datensätze in der Datenquelle, um die Spalten zu bestimmen",
			optionChangeNotSupported: "Die Änderung der folgenden Option nach der Erstellung von igGrid wird nicht unterstützt:",
			optionChangeNotScrollingGrid: "Die folgende Option kann nach der Erstellung des Rasters nicht geändert werden, da das anfängliche Raster nicht abrollt und ein komplettes erneutes Rendering notwendig ist:",
			noPrimaryKeyDefined: "Es wurde kein Primärschlüssel für das Raster definiert. Um Features wie Grid Editing verwenden zu können, muss ein Primärschlüssel definiert werden.",
			indexOutOfRange: "Der angegebene Zeilenindex liegt außerhalb des zulässigen Bereichs.",
			noSuchColumnDefined: "Der angegebene Spaltenschlüssel stimmt mit keiner der angegebenen Rasterspalten überein.",
			columnIndexOutOfRange: "Der angegebene Spaltenindex liegt außerhalb des zulässigen Bereichs.",
			recordNotFound: "Der Datensatz der angegebenen ID konnte in der Datenansicht nicht gefunden werden:",
			columnNotFound: "Es wurde keine mit dem Schlüssel übereinstimmende Spalte gefunden:",
			colPrefix: "Spalte ",
			columnVirtualizationRequiresWidth: "Virtualisierung / columnVirtualization ist auf True festgelegt, es konnte jedoch keine Breite für die Rasterspalten abgeleitet werden. Legen Sie entweder a) Rasterbreite oder b) defaultColumnWidth fest oder c) definieren Sie die Breite für jede Spalte",
			virtualizationRequiresHeight: "Virtualisierung ist auf True festgelegt, daher muss auch die Rasterhöhe festgelegt werden.",
            colVirtualizationDenied: "columnVirtualization gilt nur für feste Virtualisierung",
			noColumnsButAutoGenerateTrue: "autoGenerateColumns ist auf False festgelegt, im Raster sind jedoch keine Spalten definiert. Bitte legen Sie autoGenerateColumns auf True fest oder geben Sie manuell Spalten an",
			noPrimaryKey: "Für das igHierarchicalGrid Widget muss ein Primärschlüssel definiert werden.",
			templatingEnabledButNoTemplate: "jQueryTemplating ist auf True festgelegt, es ist jedoch kein rowTemplate definiert.",
			expandTooltip: "Zeile erweitern",
			collapseTooltip: "Zeile reduzieren",
			movingNotAllowedOrIncompatible: "Das Verschieben der angeforderten Spalte konnte nicht abgeschlossen werden. Die Spalte wurde nicht gefunden oder das Ergebnis war nicht mit dem Spaltenlayout kompatibel."
		}
	});

	$.ig.GridFiltering = $.ig.GridFiltering || {};

	$.extend($.ig.GridFiltering, {
		locale: {
			startsWithNullText: "Beginnt mit...",
			endsWithNullText: "Endet mit...",
			containsNullText: "Enthält...",
			doesNotContainNullText: "Enthält nicht...",
			equalsNullText: "Gleich...",
			doesNotEqualNullText: "Nicht gleich...",
			greaterThanNullText: "Größer als...",
			lessThanNullText: "Kleiner als...",
			greaterThanOrEqualToNullText: "Größer als oder gleich...",
			lessThanOrEqualToNullText: "Kleiner als oder gleich...",
			onNullText: "Am...",
			notOnNullText: "Nicht am...",
			emptyNullText: "Leer",
			notEmptyNullText: "Nicht leer",
			nullNullText: "Null",
			notNullNullText: "Nicht Null",
			startsWithLabel: "Beginnt mit",
			endsWithLabel: "Endet mit",
			containsLabel: "Enthält",
			doesNotContainLabel: "Enthält nicht",
			equalsLabel: "Gleich",
			doesNotEqualLabel: "Nicht gleich",
			greaterThanLabel: "Größer als",
			lessThanLabel: "Kleiner als",
			greaterThanOrEqualToLabel: "Größer als oder gleich",
			lessThanOrEqualToLabel: "Kleiner als oder gleich",
			trueLabel: "Wahr",
			falseLabel: "Falsch",
			afterLabel: "Nach",
			beforeLabel: "Vor",
			todayLabel: "Heute",
			yesterdayLabel: "Gestern",
			thisMonthLabel: "Dieser Monat",
			lastMonthLabel: "Letzter Monat",
			nextMonthLabel: "Nächster Monat",
			thisYearLabel: "Dieses Jahr",
			lastYearLabel: "Letztes Jahr",
			nextYearLabel: "Nächstes Jahr",
			clearLabel: "Filter löschen",
			noFilterLabel: "Nein",
			onLabel: "Am",
			notOnLabel: "Nicht am",
			advancedButtonLabel: "Erweitert",
			filterDialogCaptionLabel: "ADVANCED SEARCH",
			filterDialogConditionLabel1: "Datensätze anzeigen, die übereinstimmen mit ",
			filterDialogConditionLabel2: " der folgenden Kriterien",
			filterDialogOkLabel: "Suchen",
			filterDialogCancelLabel: "Abbrechen",
			filterDialogAnyLabel: "ANY",
			filterDialogAllLabel: "ALL",
			filterDialogAddLabel: "Hinzufügen",
			filterDialogErrorLabel: "Maximale Filterzahl überschritten",
			filterSummaryTitleLabel: "Suchergebnisse",
			filterSummaryTemplate: "${matches} übereinstimmende Datensätze",
			filterDialogClearAllLabel: "ALL löschen",
			tooltipTemplate: "${condition} Filter angewendet",
			// M.H. 13 Oct. 2011 Fix for bug #91007
			featureChooserText: "Filter ausblenden",
			featureChooserTextHide: "Filter anzeigen",
			// M.H. 17 Oct. 2011 Fix for bug #91007
			featureChooserTextAdvancedFilter: "Erweiterter Filter",
			virtualizationSimpleFilteringNotAllowed: "Wenn die horizontale Virtualisierung aktiviert ist, wird die einfache Filterung (Filterzeile) nicht unterstützt. Bitte legen Sie den Modus auf 'erweitert' fest und/oder aktivieren Sie advancedModeEditorsVisible nicht",
			featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie das Ladeprogramm oder eine der kombinierten Skript-Dateien."
		}
	});

	$.ig.GridGroupBy = $.ig.GridGroupBy || {};

	$.extend($.ig.GridGroupBy, {
		locale: {
			emptyGroupByAreaContent: "Ziehen Sie eine Spalte hierher oder {0} zu Gruppiert nach",
			emptyGroupByAreaContentSelectColumns: "Spalten auswählen",
			emptyGroupByAreaContentSelectColumnsCaption: "Spalten auswählen",
			expandTooltip: "Gruppierte Zeile erweitern",
			collapseTooltip: "Gruppierte Zeile reduzieren",
			removeButtonTooltip: "Gruppierte Spalte entfernen",
			featureChooserText: "Gruppieren aufheben nach",
			featureChooserTextHide: "Gruppieren nach",
			modalDialogCaptionButtonDesc: "Klicken, um aufsteigend zu sortieren",
			modalDialogCaptionButtonAsc: "Klicken, um absteigend zu sortieren",
			modalDialogCaptionButtonUngroup: "Klicken, um Gruppierung aufzuheben",
			modalDialogGroupByButtonText: "Gruppieren nach",
			modalDialogCaptionText: 'Zu Gruppieren nach hinzufügen',
			modalDialogDropDownLabel: 'Anzeige:',
			modalDialogClearAllButtonLabel: 'Alle löschen',
			modalDialogRootLevelHierarchicalGrid: 'Stamm',
			modalDialogDropDownButtonCaption: "Klicken, um anzuzeigen/auszublenden",
			modalDialogButtonApplyText: 'Übernehmen',
			modalDialogButtonCancelText: 'Abbrechen'
		}
	});

	$.ig.GridHiding = $.ig.GridHiding || {};

	$.extend($.ig.GridHiding, {
		locale: {
			columnChooserDisplayText: "Spaltenauswahl",
			hiddenColumnIndicatorTooltipText: "Ausgeblendete Spalte(n)",
			columnHideText: "Ausblenden",
			columnChooserCaptionLabel: "Spaltenauswahl",
			columnChooserCheckboxesHeader: "Ansicht",
			columnChooserColumnsHeader: "Spalte",
			columnChooserCloseButtonTooltip: "Schließen",
			hideColumnIconTooltip: "Ausblenden",
			featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie eine der kombinierten Skript-Dateien.",
			columnChooserShowText: "Anzeigen",
			columnChooserHideText: "Ausblenden",
			columnChooserResetButtonLabel: "Zurücksetzen",
			columnChooserButtonApplyText: 'Übernehmen',
			columnChooserButtonCancelText: 'Abbrechen'
		}
	});

	$.ig.GridPaging = $.ig.GridPaging || {};

	$.extend($.ig.GridPaging, {

		locale: {
			pageSizeDropDownLabel: "Anzeigen ",
			pageSizeDropDownTrailingLabel: "Datensätze",
			//pageSizeDropDownTemplate: "${dropdown} Datensätze anzeigen",
			nextPageLabelText: "Weiter",
			prevPageLabelText: "Zurück",
			firstPageLabelText: "",
			lastPageLabelText: "",
			currentPageDropDownLeadingLabel: "S.",
			currentPageDropDownTrailingLabel: "von ${count}",
			//currentPageDropDownTemplate: "S. ${dropdown} von ${count}",
			currentPageDropDownTooltip: "Seitenindex auswählen",
			pageSizeDropDownTooltip: "Anzahl der Datensätze pro Seite auswählen",
			pagerRecordsLabelTooltip: "Aktueller Datensatzbereich",
			prevPageTooltip: "Zur vorherigen Seite wechseln",
			nextPageTooltip: "Zur nächsten Seite wechseln",
			firstPageTooltip: "Zur ersten Seite wechseln",
			lastPageTooltip: "Zur letzten Seite wechseln",
			pageTooltipFormat: "Seite ${index}",
			pagerRecordsLabelTemplate: "${startRecord} - ${endRecord} von ${recordCount} Datensätzen"
		}
	});

	$.ig.GridRowSelectors = $.ig.GridRowSelectors || {};

	$.extend($.ig.GridRowSelectors, {

		locale: {
			selectionNotLoaded: "igGridSelection ist nicht initialisiert. Um den Erhalt dieser Fehlermeldung zu vermeiden, aktivieren Sie bitte das Feature Selection für das Raster oder legen Sie die Eigenschaft requireSelection property der Funktion Row Selectors auf False fest."
		}
	});

	$.ig.GridSorting = $.ig.GridSorting || {};

	$.extend($.ig.GridSorting, {
		locale: {
			sortedColumnTooltipFormat: 'sortiert ${direction}',
			unsortedColumnTooltip: 'Klicken, um Spalte zu sortieren',
			ascending: 'aufsteigend',
			descending: 'absteigend',
			modalDialogSortByButtonText: 'Sortieren nach',
			modalDialogResetButton: "Zurücksetzen",
			modalDialogCaptionButtonDesc: "Klicken, um absteigend zu sortieren",
			modalDialogCaptionButtonAsc: "Klicken, um aufsteigend zu sortieren",
			modalDialogCaptionButtonUnsort: "Klicken, um Sortierung zu entfernen",
			featureChooserText: "Nach mehreren sortieren",
			modalDialogCaptionText: "Mehrere sortieren",
			modalDialogButtonApplyText: 'Übernehmen',
			modalDialogButtonCancelText: 'Abbrechen'
			//modalDialogButtonSlideCaption: "Klicken, um sortierte Spalten anzuzeigen/auszublenden"
		}
	});

	$.ig.GridSummaries = $.ig.GridSummaries || {};

	$.extend($.ig.GridSummaries, {
		locale: {
			featureChooserText: "Zusammenfassungen ausblenden",
			featureChooserTextHide: "Zusammenfassungen anzeigen",
			dialogButtonOKText: 'OK',
			dialogButtonCancelText: 'Abbrechen',
			emptyCellText: '',
			summariesHeaderButtonTooltip: 'Zusammenfassungen anzeigen/ausblenden',
			// M.H. 13 Oct. 2011 Fix for bug 91008
			defaultSummaryRowDisplayLabelCount: 'Anzahl',
			defaultSummaryRowDisplayLabelMin: 'Min',
			defaultSummaryRowDisplayLabelMax: 'Max',
			defaultSummaryRowDisplayLabelSum: 'Summe',
			defaultSummaryRowDisplayLabelAvg: 'Durchschnitt',
			defaultSummaryRowDisplayLabelCustom: 'Benutzerdefiniert',
			calculateSummaryColumnKeyNotSpecified: "Bitte geben Sie den Spaltenschlüssel für die Berechnung der Zusammenfassung an",
			featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie eine der kombinierten Skript-Dateien."
		}
	});

	$.ig.GridUpdating = $.ig.GridUpdating || {};

	$.extend($.ig.GridUpdating, {
		locale: {
			doneLabel: 'Fertig',
			doneTooltip: 'Bearbeitung beenden und aktualisieren',
			cancelLabel: 'Abbrechen',
			cancelTooltip: 'Bearbeitung beenden und nicht aktualisieren',
			addRowLabel: 'Neue Zeile hinzufügen',
			addRowTooltip: 'Klicken, um eine neue Zeile hinzuzufügen',
			deleteRowLabel: '',
			deleteRowTooltip: 'Zeile löschen',
			igEditorException: 'Für die Aktualisierung von ui.igGrid muss ui.igEditor geladen werden',
			igComboException: 'Um den Kombinationstyp für ui.igGrid zu verwenden, muss ui.igCombo geladen werden',
			igRatingException: 'Um igRating als Editor für ui.igGrid zu verwenden, muss ui.igRating geladen werden',
			igValidatorException: 'Für die in igGridUpdating definierten Überprüfungsoptionen muss ui.igValidator geladen werden',
			noPrimaryKeyException: 'Um Aktualisierungsvorgänge zu unterstützen, nachdem eine Zeile gelöscht wurde, muss die Anwendung "primaryKey" in Optionen von igGrid definieren.',
			hiddenColumnValidationException: 'Eine Zeile mit ausgeblendeter Spalte mit aktivierter Überprüfung kann nicht bearbeitet werden.',
			dataDirtyException: 'Raster hat ausstehende Transaktionen, die das Rendern der Daten beeinflussen können Um eine Ausnahme zu vermeiden, kann die Anwendung die Option "autoCommit" von igGrid aktivieren oder sie muss das Ereignis "dataDirty" von igGridUpdating verarbeiten und False zurückgeben. Bei der Verarbeitung dieses Ereignisses kann die Anwendung auch "commit()" Daten in igGrid durchführen.',
			rowEditDialogCaptionLabel: 'Zeilendaten bearbeiten'
		}
    });

    $.ig.ColumnMoving = $.ig.ColumnMoving || {};

    $.extend($.ig.ColumnMoving, {
        locale: {
            movingDialogButtonApplyText: 'Übernehmen',
            movingDialogButtonCancelText: 'Abbrechen',
            movingDialogCaptionButtonDesc: 'Nach unten verschieben',
            movingDialogCaptionButtonAsc: 'Nach oben verschieben',
            movingDialogCaptionText: 'Spalten verschieben',
            movingDialogDisplayText: 'Spalten verschieben',
            dropDownMoveLeftText: 'Nach links verschieben',
            dropDownMoveRightText: 'Nach rechts verschieben',
            dropDownMoveFirstText: 'Erste verschieben',
            dropDownMoveLastText: 'Letzte verschieben',
            featureChooserNotReferenced: "Featureauswahl-Skript ist nicht referenziert. Um den Erhalt dieser Fehlermeldung zu vermeiden, schließen Sie bitte die Datei ig.ui.grid.featurechooser.js ein oder verwenden Sie das Ladeprogramm oder eine der kombinierten Skript-Dateien.",
            movingToolTipMove: 'Verschieben'
        }
    });

}

/*!
* Infragistics.Web.ClientUI HTML Editor localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.HtmlEditor) {
	$.ig.HtmlEditor = {};

	$.extend($.ig.HtmlEditor, {

		locale: {
			boldButtonTitle: 'Fett',
			italicButtonTitle: 'Kursiv',
			underlineButtonTitle: 'Unterstrichen',
			strikethroughButtonTitle: 'Durchgestrichen',
			increaseFontSizeButtonTitle: 'Schriftart vergrößern',
			decreaseFontSizeButtonTitle: 'Schriftart verkleinern',
			alignTextLeftButtonTitle: 'Text linksbündig ausrichten',
			alignTextRightButtonTitle: 'Text rechtsbündig ausrichten',
			alignTextCenterButtonTitle: 'Zentrieren',
			justifyButtonTitle: 'Ausrichten',
			bulletsButtonTitle: 'Aufzählungszeichen',
			numberingButtonTitle: 'Nummerierung',
			decreaseIndentButtonTitle: 'Einzug verkleinern',
			increaseIndentButtonTitle: 'Einzug vergrößern',
			insertPictureButtonTitle: 'Bild einfügen',
			fontColorButtonTitle: 'Schriftfarbe',
			textHighlightButtonTitle: 'Texthervorhebungsfarbe',
			insertLinkButtonTitle: 'Hyperlink einfügen',
			insertTableButtonTitle: 'Tabelle',
			addRowButtonTitle: 'Zeile hinzufügen',
			removeRowButtonTitle: 'Zeile entfernen',
			addColumnButtonTitle: 'Spalte hinzufügen',
			removeColumnButtonTitle: 'Spalte entfernen',
			inserHRButtonTitle: 'Horizontale Linie einfügen',
			viewSourceButtonTitle: 'Quelle anzeigen',
			cutButtonTitle: 'Ausschneiden',
			copyButtonTitle: 'Kopieren',
			pasteButtonTitle: 'Einfügen',
			undoButtonTitle: 'Rückgängig',
			redoButtonTitle: 'Wiederholen',
			imageUrlDialogText: 'Bild-URL:',
			imageAlternativeTextDialogText: 'Alternativer Text:',
			imageWidthDialogText: 'Bildbreite:',
			imageHeihgtDialogText: 'Bildhöhe:',
			linkNavigateToUrlDialogText: 'Zu URL navigieren:',
			linkDisplayTextDialogText: 'Text anzeigen:',
			linkOpenInDialogText: 'Öffnen in:',
			linkTargetNewWindowDialogText: 'Neues Fenster',
			linkTargetSameWindowDialogText: 'Gleiches Fenster',
			linkTargetParentWindowDialogText: 'Übergeordnetes Fenster',
			linkTargetTopmostWindowDialogText: 'Fenster im Vordergrund',
			applyButtonTitle: 'Übernehmen',
			cancelButtonTitle: 'Abbrechen',
			collapseButtonTitle: 'Reduzieren',
			expandButtonTitle: 'Erweitern',
			fontNames: {
				win: [
						{ text: "Times New Roman", value: "Times New Roman" },
						{ text: "Arial", value: "Arial" },
						{ text: "Arial Black", value: "Arial Black" },
						{ text: "Helvetica", value: "Helvetica" },
						{ text: "Comic Sans MS", value: "Comic Sans MS" },
						{ text: "Courier New", value: "Courier New" },
						{ text: "Georgia", value: "Georgia" },
						{ text: "Impact", value: "Impact" },
						{ text: "Lucida Console", value: "Lucida Console" },
						{ text: "Lucida Sans Unicode", value: "Lucida Sans Unicode" },
						{ text: "Palatino Linotype", value: "Palatino Linotype" },
						{ text: "Tahoma", value: "Tahoma" },
						{ text: "Trebuchet MS", value: "Trebuchet MS" },
						{ text: "Verdana", value: "Verdana" },
						{ text: "Symbol", value: "Symbol" },
						{ text: "Webdings", value: "Webdings" },
						{ text: "Wingdings", value: "Wingdings" },
						{ text: "MS Sans Serif", value: "MS Sans Serif" },
						{ text: "MS Serif", value: "MS Serif" }
					],
				mac: [
						{ text: "Times New Roman", value: "Times New Roman" },
						{ text: "Arial", value: "Arial" },
						{ text: "Arial Black", value: "Arial Black" },
						{ text: "Helvetica", value: "Helvetica" },
						{ text: "Comic Sans MS", value: "Comic Sans MS" },
						{ text: "Courier New", value: "Courier New" },
						{ text: "Georgia", value: "Georgia" },
						{ text: "Impact", value: "Impact" },
						{ text: "Monaco", value: "Monaco" },
						{ text: "Lucida Grande", value: "Lucida Grande" },
						{ text: "Book Antiqua", value: "Book Antiqua" },
						{ text: "Geneva", value: "Geneva" },
						{ text: "Trebuchet MS", value: "Trebuchet" },
						{ text: "Verdana", value: "Verdana" },
						{ text: "Symbol", value: "Symbol" },
						{ text: "Webdings", value: "Webdings" },
						{ text: "Zapf Dingbats", value: "Zapf Dingbats" },
						{ text: "New York", value: "New York" }
					]
			},
			fontSizes: [
				{ text: "1", value: "1 (8pt)", style: "xx-small"},
				{ text: "2", value: "2 (9pt)", style: "x-small" },
				{ text: "3", value: "3 (10pt)", style: "small" },
				{ text: "4", value: "4 (12pt)", style: "medium" },
				{ text: "5", value: "5 (14pt)", style: "large" },
				{ text: "6", value: "6 (16pt)", style: "x-large" },
				{ text: "7", value: "7 (18pt)", style: "xx-large" }
			],
			formatsList: [
					{ text: "h1", value: "Heading 1" },
					{ text: "h2", value: "Heading 2" },
					{ text: "h3", value: "Heading 3" },
					{ text: "h4", value: "Heading 4" },
					{ text: "h5", value: "Heading 5" },
					{ text: "h6", value: "Heading 6" }
				]
		}

	});
}

/*!
* Infragistics.Web.ClientUI Tree localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.Tree) {
	$.ig.Tree = {};

	$.extend($.ig.Tree, {
		locale: {
			invalidArgumentType: 'Ungültiger Argumenttyp angegeben.',
			errorOnRequest: 'Beim Abrufen von Daten ist ein Fehler aufgetreten: ',
			noDataSourceUrl: 'Für die igTree Steuerung muss eine dataSourceUrl angegeben werden, um eine Anforderung für Daten an diese URL zu initiieren.',
			incorrectPath: 'Am angegebenen Pfad wurde kein Knoten gefunden: ',
			incorrectNodeObject: 'Das angegebene Argument ist kein jQuery Knotenelement.',
			setOptionError: 'Laufzeit-Änderungen sind für die folgende Option nicht zugelassen: ',
			moveTo: '<strong>Verschieben nach</strong> {0}',
			moveBetween: '<strong>Verschieben zwischen</strong> {0} und {1}',
			moveAfter: '<strong>Verschieben nach</strong> {0}',
			moveBefore: '<strong>Verschieben vor</strong> {0}',
			copyTo: '<strong>Kopieren nach</strong> {0}',
			copyBetween: '<strong>Kopieren zwischen</strong> {0} und {1}',
			copyAfter: '<strong>Kopieren nach</strong> {0}',
			copyBefore: '<strong>Kopieren vor</strong> {0}',
			and: 'und'
		}
	});

}

/*!
* Infragistics.Web.ClientUI Upload localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.Upload) {
	$.ig.Upload = {};

	$.extend($.ig.Upload, {

		locale: {
			labelUploadButton: "Datei hochladen",
			labelAddButton: "Hinzufügen",
			labelClearAllButton: "Hochgeladene löschen",
			// M.H. 13 May 2011 - fix bug 75042
			labelSummaryTemplate: "{0} von {1} hochgeladenen",
			labelSummaryProgressBarTemplate: "{0}/{1}",
			labelShowDetails: "Details anzeigen",
			labelHideDetails: "Details ausblenden",
			labelSummaryProgressButtonCancel: "Abbrechen",
			// M.H. 1 June 2011 Fix bug #77532
			labelSummaryProgressButtonContinue: "Hochladen",
			labelSummaryProgressButtonDone: "Fertig",
			labelProgressBarFileNameContinue: "...",

			//error messages
			errorMessageFileSizeExceeded: "Max. Dateigröße überschritten",
			errorMessageGetFileStatus: "Ihr aktueller Dateistatus konnte nicht erfasst werden! Wahrscheinlich ist Verbindung abgebrochen.",
			errorMessageCancelUpload: "Befehl zum Abbrechen des Upload-Vorgangs konnte nicht an Server gesendet werden! Wahrscheinlich ist Verbindung abgebrochen.",
			errorMessageNoSuchFile: "Die angeforderte Datei konnte nicht gefunden werden. Wahrscheinlich ist diese Datei zu groß.",
			errorMessageOther: "Beim Hochladen der Datei ist ein interner Fehler aufgetreten. Fehlercode: {0}.",
			errorMessageValidatingFileExtension: "Überprüfung der Datenerweiterung ist fehlgeschlagen.",
			errorMessageAJAXRequestFileSize: "Beim Erfassen der Dateigröße ist ein AJAX-Fehler aufgetreten.",
			errorMessageMaxUploadedFiles: "Die maximale Anzahl von hochladbaren Dateien wurde überschritten.",
			errorMessageMaxSimultaneousFiles: "Der Wert von maxSimultaneousFilesUploads ist falsch. Er muss mehr als 0 oder Null lauten.",
			errorMessageTryToRemoveNonExistingFile: "Sie versuchen, eine nicht vorhandene Datei mit ID {0} zu entfernen.",
			errorMessageTryToStartNonExistingFile: "Sie versuchen, eine nicht vorhandene Datei mit ID {0} zu starten.",

			// M.H. 12 May 2011 - fix bug 74763: add title to all buttons
			// title attributes            
			titleUploadFileButtonInit: "Datei hochladen",
			titleAddFileButton: "Hinzufügen",
			titleCancelUploadButton: "Abbrechen",
			// M.H. 1 June 2011 Fix bug #77532
			titleSummaryProgressButtonContinue: "Hochladen",
			titleClearUploaded: "Hochgeladene löschen",
			titleShowDetailsButton: "Details anzeigen",
			titleHideDetailsButton: "Details ausblenden",
			titleSummaryProgressButtonCancel: "Abbrechen",
			titleSummaryProgressButtonDone: "Fertig",
			// M.H. 1 June 2011 Fix bug #77532
			titleSingleUploadButtonContinue: "Hochladen",
			titleClearAllButton: "Hochgeladene löschen"
		}
	});

}


/*!
* Infragistics.Web.ClientUI Validator localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

/*global $ */
$.ig = $.ig || {};

if (!$.ig.Validator) {
	$.ig.Validator = {
		locale: {
			defaultMessage: 'Bitte korrigieren Sie dieses Feld',
			selectMessage: 'Bitte wählen Sie einen Wert aus',
			rangeSelectMessage: 'Bitte wählen Sie nicht mehr als {0} und nicht weniger als {1} Elemente',
			minSelectMessage: 'Bitte wählen Sie mindestens {0} Elemente',
			maxSelectMessage: 'Bitte wählen Sie nicht mehr als {0} Elemente',
			rangeLengthMessage: 'Bitte geben Sie einen Wert zwischen {0} und {1} Zeichen ein',
			minLengthMessage: 'Bitte geben Sie mindestens {0} Zeichen ein',
			maxLengthMessage: 'Bitte geben Sie nicht mehr als {0} Zeichen ein',
			requiredMessage: 'Dieses Feld ist erforderlich',
			maskMessage: 'Bitte füllen Sie alle erforderlichen Positionen aus',
			dateFieldsMessage: 'Bitte geben Sie Werte in Datumsfelder ein',
			invalidDayMessage: 'Ungültiger Tag des Monats Bitte geben Sie einen korrekten Tag ein',
			dateMessage: 'Bitte geben Sie ein gültiges Datum ein',
			numberMessage: 'Bitte geben Sie eine gültige Nummer ein',
			rangeMessage: 'Bitte geben Sie einen Wert zwischen {0} und {1} ein',
			minMessage: 'Bitte geben Sie einen Wert größer oder gleich {0} ein',
			maxMessage: 'Bitte geben Sie einen Wert kleiner oder gleich {0} ein'
		}
	};
}

/*!
* Infragistics.Web.ClientUI Video Player localization resources 12.2.20122.2029
*
* Copyright (c) 2011-2012 Infragistics Inc.
*
* http://www.infragistics.com/
*
*/

$.ig = $.ig || {};

if (!$.ig.VideoPlayer) {
	$.ig.VideoPlayer = {};

	$.extend($.ig.VideoPlayer, {

		locale: {
			liveStream: "Live-Video",
			live: "Live",
			paused: "Pause",
			playing: "Wiedergabe",
			play: 'Wiedergeben',
			volume: "Lautstärke",
			unsupportedVideoSource: "Die aktuellen Videoquellen enthalten kein Format, das von Ihrem Browser unterstützt wird.",
			missingVideoSource: "Keine kompatible Videoquelle.",
			progressLabelLongFormat: "$currentTime$ / $duration$",
			progressLabelShortFormat: "$currentTime$",
			enterFullscreen: "In Vollbildmodus wechseln",
			exitFullscreen: "Vollbildmodus beenden",
			skipTo: "ÜBERSPRINGEN ZU",
			unsupportedBrowser: "Der aktuelle Browser unterstützt HTML5 Video nicht. <br/>Führen Sie ein Upgrade auf eine der folgenden Versionen durch:",
			currentBrowser: "Aktueller Browser: {0}",
			ie9: "Microsoft Internet Explorer V 9+",
			chrome8: "Google Chrome V 8+",
			firefox36: "Mozilla Firefox V 3.6+",
			safari5: "Apple Safari V 5+",
			opera11: "Opera V 11+",
			ieDownload: "http://www.microsoft.com/windows/internet-explorer/default.aspx",
			operaDownload: "http://www.opera.com/download/",
			chromeDownload: "http://www.google.com/chrome",
			firefoxDownload: "http://www.mozilla.com/",
			safariDownload: "http://www.apple.com/safari/download/",
			buffering: 'Pufferung...',
			adMessage: 'Anzeige: Das Video wird in $duration$ Sekunden fortgesetzt.',
			adMessageLong: 'Anzeige: Das Video wird in $duration$ fortgesetzt.',
			adMessageNoDuration: 'Anzeige: Das Video wird nach der Werbung fortgesetzt.',
			adNewWindowTip: 'Anzeige: Klicken, um Anzeigeinhalt in einem neuen Fenster zu öffnen.',
			nonDivException: 'Der Infragistics HTML5 Videoplayer kann nur auf einem DIV Tag instanziiert werden.',
			relatedVideos: 'VERWANDTE VIDEOS',
			replayButton: 'Wiedergeben',
			replayTooltip: 'Klicken, um das letzte Video wiederzugeben.'
		}
	});

}


