var OpenTaskRowNames = {
  Id: 0,
  IncidentId: 1,
  DepartmentId: 2,
  TaskTypeId: 3,
  Comments: 4,
  State: 5,
  CreationDate: 6,
  ClosingDate: 7
};

var OpenTaskStatus = {
  Open: 1,
  Closed: 2,
  Canceled: 3
};

(function(window) {
  'strict';

  function getRowValues(gridView) {
    var focusedRowIndex = gridView.GetFocusedRowIndex();
    return gridView.cpRowValues[focusedRowIndex - gridView.visibleStartIndex];
  };

  window.OpenTaskGridView_Init = function(s, e) {
    window.AppContext.MasterGrid = s;
    window.GlobalGridView_Init(s, e);
    window.GlobalGridView_AdjustSize(s);
  };

  window.OpenTaskGridView_BeginCallback = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.TaskId = window.AppContext.TaskId;
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.FocusedRowKey = s.GetRowKey(focusedRowIndex);
  };

  window.OpenTaskGridView_EndCallback = function(s, e) {
    if (s.cpFocusedRowIndex > -1) {
      s.SetFocusedRowIndex(s.cpFocusedRowIndex);
    }
    window.GlobalGridView_EndCallback(s, e);
    OpenTaskGridView_AdjustToolbarState(s);
  };

  window.OpenTaskGridView_FocusedRowChanged = function(s, e) {
    OpenTaskGridView_AdjustToolbarState(s);
  };

  window.OpenTaskGridView_DetailRowExpanding = function(s, e) {
    var rowKeys = s.GetRowKey(e.visibleIndex).split("|");
    window.AppContext.IncidentId = rowKeys[0];
    window.AppContext.TaskId = rowKeys[1];
    s.SetFocusedRowIndex(e.visibleIndex);
  };

  window.OpenTaskGridView_DetailRowCollapsing = function(s, e) {
    window.AppContext.IncidentId = null;
    window.AppContext.TaskId = null;
  };

  window.OpenTaskGridView_ToolbarItemClick = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();

    switch (e.item.name) {
    case "CmdEditOpenTask":
      if (focusedRowIndex > -1) {
        s.StartEditRow(focusedRowIndex);
      }
      break;
    }
  };

  function setCmdEditOpenTaskEnabled(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var editingRowVisibleIndex = s.cpEditingRowVisibleIndex;
    var rowValues = getRowValues(s);
    var cmdEditTask = s.GetToolbar(0).GetItemByName("CmdEditOpenTask");
    cmdEditTask.SetEnabled(
      focusedRowIndex > -1
      && focusedRowIndex !== editingRowVisibleIndex
      && (AppContext.DepartmentId == rowValues[OpenTaskRowNames.DepartmentId] || AppContext.IsAdmin)
      && !AppContext.AutomatedTaskTypes.includes(rowValues[OpenTaskRowNames.TaskTypeId])
    );
  }

  window.OpenTaskGridView_AdjustToolbarState = function(s) {
    setCmdEditOpenTaskEnabled(s);
  };

})(window);