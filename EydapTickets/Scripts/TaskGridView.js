var TaskRowNames = {
  Id: 0,
  IncidentId: 1,
  DepartmentId: 2,
  TaskTypeId: 3,
  Comments: 4,
  State: 5,
  CreationDate: 6,
  ClosingDate: 7
};

var TaskStatus = {
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

  window.TaskGridView_Init = function(s, e) {
    // NOOP
  };

  window.TaskGridView_BeginCallback = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    e.customArgs.IncidentId = window.AppContext.IncidentId;
    e.customArgs.TaskId = window.AppContext.TaskId;
    e.customArgs.FocusedRowKey = s.GetRowKey(focusedRowIndex);
  };

  window.TaskGridView_EndCallback = function(s, e) {
    if (s.cpFocusedRowIndex > -1) {
      s.SetFocusedRowIndex(s.cpFocusedRowIndex);
    }
    TaskGridView_AdjustToolbarState(s);
  };

  window.TaskGridView_FocusedRowChanged = function(s, e) {
    TaskGridView_AdjustToolbarState(s);
  };

  window.TaskGridView_DetailRowExpanding = function(s, e) {
    window.AppContext.TaskId = s.GetRowKey(e.visibleIndex);
    s.SetFocusedRowIndex(e.visibleIndex);
  };

  window.TaskGridView_DetailRowCollapsing = function(s, e) {
    window.AppContext.TaskId = null;
  };

  window.TaskGridView_ToolbarItemClick = function(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();

    switch (e.item.name) {
    case "CmdAddNewTask":
      s.AddNewRow();
      break;

    case "CmdEditTask":
      if (focusedRowIndex > -1) {
        s.StartEditRow(focusedRowIndex);
      }
      break;
    }
  };

  function setCmdAddNewTaskEnabled(s) {
    var cmdAddNewTask = s.GetToolbar(0).GetItemByName("CmdAddNewTask");
    cmdAddNewTask.SetEnabled(true);
  }

  function setCmdEditTaskEnabled(s, e) {
    var focusedRowIndex = s.GetFocusedRowIndex();
    var editingRowVisibleIndex = s.cpEditingRowVisibleIndex;

    var cmdEditTask = s.GetToolbar(0).GetItemByName("CmdEditTask");
    cmdEditTask.SetEnabled(
      focusedRowIndex > -1
      && focusedRowIndex !== editingRowVisibleIndex
    );
  }

  window.TaskGridView_AdjustToolbarState = function(s) {
    setCmdAddNewTaskEnabled(s);
    setCmdEditTaskEnabled(s);
  };

})(window);
