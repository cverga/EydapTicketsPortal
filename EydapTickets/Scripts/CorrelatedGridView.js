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

  window.CorrelatedGridView_Init = function(s, e) {
    window.AppContext.MasterGrid = s;
    window.GlobalGridView_Init(s, e);
    window.GlobalGridView_AdjustSize(s);
  };

  window.CorrelatedGridView_BeginCallback = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.FocusedRowKey = s.GetRowKey(focusedRowIndex);
  };

  window.CorrelatedGridView_EndCallback = function(s, e) {
    if (s.cpFocusedRowIndex > -1) {
      s.SetFocusedRowIndex(s.cpFocusedRowIndex);
    }
    window.GlobalGridView_EndCallback(s, e);
    CorrelatedGridView_SetToolbarState(s);
  };

  window.CorrelatedGridView_DetailRowExpanding = function(s, e) {
    window.AppContext.IncidentId = s.GetRowKey(e.visibleIndex);
    s.SetFocusedRowIndex(e.visibleIndex);
  };

  window.CorrelatedGridView_DetailRowCollapsing = function(/*s, e*/) {
    window.AppContext.IncidentId = null;
  };

  window.CorrelatedGridView_ToolbarItemClick = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var focusedRowKey = s.GetRowKey(focusedRowIndex);
    switch (e.item.name) {
    case "CmdClearIncidentCorrelation":
      if (focusedRowIndex > -1) {
        var userConfirmation = confirm('Είστε βέβαιοι ότι θέλετε να αποσυσχετίσετε το επιλεγμένο Περιστατικο;');
        if (userConfirmation) {
          ClearTTCorrelation(focusedRowKey);
        }
      }
      break;
    }
  };

  window.CorrelatedGridView_FocusedRowChanged = function(s/*, e*/) {
    CorrelatedGridView_SetToolbarState(s);
  };

  function setCmdClearIncidentCorrelation(s) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var command = s.GetToolbar(0).GetItemByName("CmdClearIncidentCorrelation");
    command.SetEnabled(
      focusedRowIndex > -1
    );
  };

  window.CorrelatedGridView_SetToolbarState = function(s) {
    setCmdClearIncidentCorrelation(s);
  };

})(window);
