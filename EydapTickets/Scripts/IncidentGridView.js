var IncidentRowNames = {
  Id: 0,
  MyDepartmentColor: 1,
  OtherDepartmentColor: 2,
  Comments: 3,
  Status: 4,
  Latitude: 5,
  Longitude: 6
};

 var IncidentStatus = {
   Open: 1,
   //Closed: 2,
   Closed: 3,
   Archived: 4,
   Canceled: 5,
   ClosedWithPendingTasks: 6,
   Rerouted: 7,
   SewageRelated: 8
};

(function(window) {
  'strict';

  function getRowValues(gridView) {
    var focusedRowIndex = gridView.GetFocusedRowIndex();
    return gridView.cpRowValues[focusedRowIndex - gridView.visibleStartIndex];
  };

  window.IncidentGridView_Init = function(s, e) {
    window.AppContext.MasterGrid = s;
    window.AppContext.FilterTTs = false;
    window.GlobalGridView_Init(s, e);
    window.GlobalGridView_AdjustSize(s);
  };

  window.IncidentGridView_BeginCallback = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.HideMine = window.AppContext.FilterTTs;
    e.customArgs.FocusedRowKey = s.GetRowKey(focusedRowIndex);
  };

  window.IncidentGridView_EndCallback = function(s, e) {
    if (s.cpFocusedRowIndex > -1) {
      s.SetFocusedRowIndex(s.cpFocusedRowIndex);
    }
    window.GlobalGridView_EndCallback(s, e);
    IncidentGridView_SetToolbarState(s);
  };

  window.IncidentGridView_DetailRowExpanding = function(s, e) {
    window.AppContext.IncidentId = s.GetRowKey(e.visibleIndex);
    s.SetFocusedRowIndex(e.visibleIndex);
  };

  window.IncidentGridView_DetailRowCollapsing = function(/*s, e*/) {
    window.AppContext.IncidentId = null;
  };

  window.IncidentGridView_ToolbarItemClick = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var focusedRowKey = s.GetRowKey(focusedRowIndex);

    switch (e.item.name) {
    case "CmdRouteIncident":
      if (focusedRowIndex > -1) {
        window.RTT = focusedRowKey;
        window.routepopup.Show();
        window.ShowAjaxRoutingPopUp(focusedRowKey);
      }
      break;

    case "CmdShowIncidentInfo":
      if (focusedRowIndex > -1) {
        window.RTT = focusedRowKey;
        window.detailspopup.Show();
        window.ShowAjaxDetailsPopUp(focusedRowKey);
      }
      break;

    case "CmdShowIncidentLocation":
      if (focusedRowIndex > -1) {
        var rowValues = getRowValues(s);
        var latitude = rowValues[IncidentRowNames.Latitude].toString();
        var longitude = rowValues[IncidentRowNames.Longitude].toString();
        var locateUrl = window.AppContext.LocateIncidentUrl
          .replace("{0}", latitude.replace(",", "."))
          .replace("{1}", longitude.replace(",", "."));
        window.open(locateUrl);
      }
      break;

    case "CmdPrintIncidentForm":
      if (focusedRowIndex > -1) {
        var printUrl = window.AppContext.PrintIncidentUrl.replace("{0}", focusedRowKey);
        window.open(printUrl);
      }
      break;
    }
  };

  window.IncidentGridView_FocusedRowChanged = function(s/*, e*/) {
    IncidentGridView_SetToolbarState(s);
  };

  function setCmdRouteIncidentEnabled(s) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var rowValues = getRowValues(s);
    var command = s.GetToolbar(0).GetItemByName("CmdRouteIncident");
    command.SetEnabled(
      focusedRowIndex > -1
      && rowValues[IncidentRowNames.Status] === IncidentStatus.Open
    );
  };

  function setCmdShowIncidentInfoEnabled(s) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var command = s.GetToolbar(0).GetItemByName("CmdShowIncidentInfo");
    command.SetEnabled(
      focusedRowIndex > -1
    );
  };

  function setCmdShowIncidentLocationEnabled(s) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var rowValues = getRowValues(s);
    var command = s.GetToolbar(0).GetItemByName("CmdShowIncidentLocation");
    command.SetEnabled(
      focusedRowIndex > -1
      && rowValues[IncidentRowNames.Latitude].toString().trim() !== ""
      && rowValues[IncidentRowNames.Longitude].toString().trim() !== ""
    );
  }

  function setCmdPrintIncidentFormEnabled(s) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var command = s.GetToolbar(0).GetItemByName("CmdPrintIncidentForm");
    command.SetEnabled(
      focusedRowIndex > -1
    );
  }

  window.IncidentGridView_SetToolbarState = function(s) {
    setCmdRouteIncidentEnabled(s);
    setCmdShowIncidentInfoEnabled(s);
    setCmdShowIncidentLocationEnabled(s);
    setCmdPrintIncidentFormEnabled(s);
  };

})(window);
