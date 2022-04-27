var AssignmentRowNames = {
  Id: 0,
  MyDepartmentColor: 1,
  OtherDepartmentColor: 2,
  Comments: 3,
  Status: 4,
  Latitude: 5,
  Longitude: 6
};

var AssignmentStatus = {
  Open: 1,
  Closed: 2,
  Canceled: 3
};

(function(window) {
  'strict';

  window.AssignmentGridView_Init = function(s, e) {
    // NOOP
  };

  window.AssignmentGridView_BeginCallback = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.TaskId = window.AppContext.TaskId;
    e.customArgs.AssignmentId = window.AppContext.AssignmentId;
    e.customArgs.FocusedRowKey = s.GetRowKey(focusedRowIndex);
  };

  window.AssignmentGridView_EndCallback = function(s/*, e*/) {
    if (s.cpFocusedRowIndex > -1) {
      s.SetFocusedRowIndex(s.cpFocusedRowIndex);
    }
    AssignmentGridView_SetToolbarState(s);
  };

  window.AssignmentGridView_FocusedRowChanged = function(s/*, e*/) {
    AssignmentGridView_SetToolbarState(s);
  };

  window.AssignmentGridView_DetailRowExpanding = function(s, e) {
    window.AppContext.AssignmentId = s.GetRowKey(e.visibleIndex);
    s.SetFocusedRowIndex(e.visibleIndex);
  };

  window.AssignmentGridView_DetailRowCollapsing = function(/*s, e*/) {
    window.AppContext.AssignmentId = null;
  };

  window.AssignmentGridView_ToolbarItemClick = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();

    switch (e.item.name) {
    case "CmdAddNewAssignment":
      s.AddNewRow();
      break;

    case "CmdEditAssignment":
      if (focusedRowIndex > -1) {
        s.StartEditRow(focusedRowIndex);
      }
      break;
    }
  };

  window.AssignmentGridView_SetToolbarState = function(s) {
    SetCmdAddNewAssignmentEnabled(s);
    SetCmdEditAssignmentEnabled(s);
  }

  window.SetCmdAddNewAssignmentEnabled = function(s) {
    var cmdAddNewAssignment = s.GetToolbar(0).GetItemByName("CmdAddNewAssignment");
    cmdAddNewAssignment.SetEnabled(true);
  };

  window.SetCmdEditAssignmentEnabled = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var editingRowVisibleIndex = s.cpEditingRowVisibleIndex;

    var cmdEditAssignment = s.GetToolbar(0).GetItemByName("CmdEditAssignment");
    cmdEditAssignment.SetEnabled(
      focusedRowIndex > -1 && focusedRowIndex !== editingRowVisibleIndex
    );
  };

})(window);
