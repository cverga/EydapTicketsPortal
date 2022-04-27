
var App = (function () {
    var LOG_DEBUG = 1000;
    var LOG_INFO = 500;
    var LOG_ERROR = 0;
    // Class HierarchyController
    function HierarchyController() {
        var emptyOptionValue = "-1";

        this.EntityPostback = '';
        this.ValuePostback = '';
        this.ValuePostbackObject;
        this.app = null;

        this.prepareLookups = function () {
            var scope = "PrepareHierarchyLookups";
            if (this.bindHierarchyData() == 0) {
                // Do nothing
            }
            else {
                $("select.hierarchy").prop("disabled", true);

                //$(".hierarchy_0").each(function (index, e) {
                //    onHierarchyChanged(e, null);
                //});
                var rootElements = $(".hierarchy_0");
                for (var i = 0; i < rootElements.length; i++) {
                    this.onHierarchyChanged(rootElements[i], null);
                }
            }
            if (this.ValuePostback != undefined && this.ValuePostback != '')
                this.ValuePostbackObject = JSON.parse(this.ValuePostback);

            // Bind event handlers - this: the HierarchyController object
            $("select.hierarchy").on('change keyup', this, function (e) {
                // Handle special keys: TAB SHIFT
                if (e.which == 9 || e.which == 16)
                    return;

                var e_jq = $(e.target);
                var handleEvent = true;
                if (e.data.ValuePostbackObject != undefined) {
                    $.each(e.data.ValuePostbackObject, function (index, obj) {
                        if (e.target.id.indexOf(obj.Entity) > -1) {
                            if (obj.Values != undefined) {
                                $.each(obj.Values, function (i, item) {
                                    if (e.target.value == item) {
                                        var url = "cat=" + e.target.value + "." + new Date().getTime();
                                        if (document.location.pathname != undefined) {
                                            if (document.location.search != undefined)
                                                url = document.location.search + "&" + url;
                                            else
                                                url = "?" + url;
                                            url = document.location.pathname + url;
                                        }
                                        else
                                            url = "/request/create?" + url;
                                        $.ajax({
                                            type: "get", url: url, dataType: 'html', context: e.data,
                                            success: function (data, status, jqXHR) {
                                                handleEvent = false;
                                                $(".hierarchy").unbind('change keyup');
                                                $(".view-content").html(data);
                                                //this.prepareLookups();
                                                this.bindHierarchyData();
                                            },
                                            error: function (jqXHR, status, error) {
                                                this.app.HandleError("", "", error);
                                            },
                                            complete: function (data) {
                                            }
                                        });
                                    }
                                });
                            }
                        }
                    });
                }

                if (handleEvent)
                    e.data.onHierarchyChanged(e.target, e.target.value);
            });

        }

        this.bindHierarchyData = function () {
            var scope = "BindHierarchyData";
            var e_jq = $(".hierarchy-hidden");
            var entity = e_jq.attr("data-hierarchyentity");
            var id = e_jq.val();

            if (id == undefined || id == "" || id == "0")
                return -1;

            var url = e_jq.attr("data-apiurl") + e_jq.attr("data-apifilter");
            var url1 = url.replace("[ID]", id);
            if (this.app != undefined && this.app != null)
                this.app.Notify("", true);
            $.ajax({
                type: "get", url: url1, context: this,
                success: function (data, status, jqXHR) {
                    var hierarchyLast = $("#" + entity + "_" + (data.HierarchyLevel - 1));
                    if (hierarchyLast.length > 0) {
                        hierarchyLast.val(data.CategoryName);
                        if (this.app != undefined && this.app != null)
                            this.app.Log(scope, hierarchyLast[0].id + " - Level: " + data.HierarchyLevel, LOG_DEBUG);

                        // HierarchyLevel is 1-based, so subtract 1 to revert to 0-based
                        var counter = data.HierarchyLevel - 1;
                        var parent_ids;
                        if (data.Parents.indexOf(",") == 0)
                            data.Parents = data.Parents.substr(1);
                        parent_ids = data.Parents.split(",");
                        var last_child;
                        for (var i = 0; i < counter; i++) {
                            var children = $("[id='" + entity + "_" + i + "']");
                            if (i == counter - 1)
                                last_child = children;
                            if (children.length > 0) {
                                var url2 = url.replace("[ID]", (parent_ids[i]));
                                $.ajax({
                                    type: "get", url: url2, context: children, complete: function (data, status, jqXHR) {
                                        this.val(data.responseJSON.CategoryName);
                                    }
                                });
                            }
                        }

                        if (this.app != undefined && this.app != null)
                            this.app.Log(scope, "Fetching data for: " + hierarchyLast[0].id, LOG_DEBUG);
                        this.onHierarchyChanged(hierarchyLast[0], id);

                    }
                    if (this.app != undefined && this.app != null)
                        this.app.ClearNotifications();
                },
                error: function (jqXHR, status, error) {
                    this.app.HandleError("", "", error);
                },
                complete: function (data) {
                }
            });
            return 0;
        }

        this.bindControlData = function (control, data) {
            if (data != null && data != undefined && data.responseJSON != undefined) {

                $("<option value='" + emptyOptionValue + "'></option>").appendTo($(control));
                $.each(data.responseJSON, function (i, item) {
                    $("<option value='" + item.Id + "'>" + item.CategoryName + "</option>").appendTo($(control));
                });
            }
        }

        this.onHierarchyChanged = function (e, value) {
            var scope = "OnHierarchyChanged";
            var parentId = "null";
            var e_jq = $(e);

            if (e_jq.length > 0) {
                var entity = e_jq.attr("data-hierarchyentity");
                var id_text = e_jq[0].id.replace(entity + "_", "");
                var id = parseInt(id_text);
                var executeAjax = true;

                if (value == emptyOptionValue) {
                    executeAjax = (id == 0);
                    value = null;
                }
                if (value != null)
                    parentId = value;

                var counter = id + 1;
                while (true) {
                    var children = $("[id='" + entity + "_" + counter + "']");
                    if (children.length == 0)
                        break;

                    children.html("");
                    counter++;
                }

                if (value != null && value != emptyOptionValue) {
                    var children = $("[id='" + entity + "_" + (id + 1) + "']");
                    if (children.length > 0) {
                        e_jq = children;
                    }
                    else {
                        var newvalue = e_jq.val();
                        if (!isNaN(newvalue)) {
                            var hidden = $("#" + entity);
                            hidden.val(e_jq.val());
                        }
                    }
                }

                var url = e_jq.attr("data-apiurl") + e_jq.attr("data-apifilter").replace("[PARENT_ID]", parentId);
                if (id == 0)
                    e_jq.html("");

                if (executeAjax) {
                    if (this.app != undefined && this.app != null)
                        this.app.Notify("", true);
                    if (this.app != undefined && this.app != null)
                        this.app.Log(e_jq[0].id, "Fetch data from: " + url, LOG_DEBUG);
                    $.ajax({
                        type: "get", url: url, context: this,
                        success: function (data, status, jqXHR) {
                            $("[id^='" + entity + "_']").attr("disabled", true);
                            this.bindControlData(e_jq, jqXHR);
                            //e_jq.attr("disabled", false);
                            var counter = id;
                            if (value != null)
                                counter = id + 1;
                            for (var i = 0; i <= counter; i++) {
                                var children = $("[id='" + entity + "_" + i + "']");
                                if (children.length > 0)
                                    children.attr("disabled", false);
                                if (i >= id + 1)
                                    $("#select2-" + entity + "_" + i + "-container").html("");
                            }
                            var children2 = $("[id^='" + entity + "_']");
                            for (var i = 0; i < children2.length; i++) {
                                var tmp_id = parseInt(children2[i].id.replace(entity + "_", ""));
                                if (tmp_id >= id + 1)
                                    $("#select2-" + entity + "_" + i + "-container").html("");
                            }
                            if (this.app != undefined && this.app != null)
                                this.app.ClearNotifications();
                        },
                        error: function (jqXHR, status, error) {
                            this.app.HandleError("", "", error);
                        },
                        complete: function (data) {
                        }
                    });
                }
            }
        }
    }

    // Class DynamicContentController
    function DynamicContentController() {
        var emptyOptionValue = "-1";

        this.app = null;

        this.prepareContent = function () {
            var scope = "PrepareDynamicContent";
            var ctrls = $(".dynamic-content");

            ctrls.attr("disabled", true);
            //$.each(ctrls, function (i, item) {
            //    var ctrlId = item.id.replace("_0", "");
            //    var value = $("#" + ctrlId).val();
            //    var item_jq = $(item);
            //    bindDynamicContent(item, value, item_jq.attr("data-fieldvalue"), item_jq.attr("data-fieldtext"));
            //});
            for (var i = 0; i < ctrls.length; i++) {
                var ctrlId = ctrls[i].id.replace("_0", "");
                if (ctrls[i].id.indexOf("_PLACEHOLDER") > -1)
                    ctrlId = ctrls[i].id.replace("_PLACEHOLDER", "");
                var value = $("#" + ctrlId).val();
                var item_jq = $(ctrls[i]);

                this.bindDynamicContent(ctrls[i], value, item_jq.attr("data-fieldvalue"), item_jq.attr("data-fieldtext"));
                if (item_jq.attr("data-apifilter") === undefined || item_jq.attr("data-apifilter").length == 0) {
                }
                else {
                    // Cascaded dropdown listbox, bind to dependent control's change event
                    // Bind event handlers - this: Array, the DynamicContentController object & the current control
                    var controlSelector = "#" + item_jq.attr("data-apifilter") + "_0";
                    if ($(controlSelector).length == 0)
                        controlSelector = "#" + item_jq.attr("data-apifilter");
                    $(controlSelector).on('change keyup', [ this, ctrls[i] ], function (e) {
                        // Handle special keys: TAB SHIFT
                        if (e.which == 9 || e.which == 16)
                            return;

                        var item_jq = $(e.data[1]);
                        e.data[0].bindDynamicContent(e.data[1], item_jq.val(), item_jq.attr("data-fieldvalue"), item_jq.attr("data-fieldtext"), e.target.value);
                    });
                }
            }


            // Bind event handlers - this: the DynamicContentController object
            ctrls.on('change keyup', this, function (e) {
                // Handle special keys: TAB SHIFT
                if (e.which == 9 || e.which == 16)
                    return;
                e.data.onDynamicContentChanged(e.target, e.target.value);
            });
        }

        this.onDynamicContentChanged = function (e, value) {
            var scope = "OnDynamicContentChanged";
            if (e.tagName == "INPUT" && e.type == "checkbox") {
                var ctrlId = e.id.substr(0, e.id.indexOf("_"));
                var ctrls = $("input[id^='" + ctrlId + "_']");
                var newValue = "";
                var dynamicvalue = $("#" + ctrlId + "_PLACEHOLDER").data("dynamicvalue");
                for (var i = 0; i < ctrls.length; i++) {
                    if (ctrls[i].id.indexOf("PLACEHOLDER") == -1) {
                        var id = parseInt(ctrls[i].id.substr(ctrls[i].id.indexOf("_") + 1));

                        if (ctrls[i].checked)
                            newValue += id + ",";
                    }
                }
                if (this.app != undefined && this.app != null && this.app.CallbackFunctionsManager != null) {
                    this.app.CallbackFunctionsManager.CallCallbackFunction("DynamicContent###" + ctrlId + "_PLACEHOLDER.onChanged", { ctrl: $(e), ctrlId: ctrlId, dynamicvalue: dynamicvalue, groupValues: newValue });
                }
                else
                    $("#" + ctrlId).val(newValue);
            }
            else {
                var ctrlId = e.id.replace("_0", "");
                var value = $("#" + ctrlId).val(value);
            }
        }

        this.bindDynamicContent = function (e, value, fieldValue, fieldText, cascadedValue) {
            var scope = "BindDynamicContent";
            var e_jq = $(e);

            if (e_jq.length > 0) {
                var executeAjax = true;

                if (executeAjax) {
                    e_jq.html("");
                    var url = e_jq.attr("data-apiurl");
                    if (cascadedValue !== undefined) {
                        console.log('cascadedValue: ' + cascadedValue);
                        if (url.indexOf("[[CASCADED_VALUE]]") > 0)
                            url = url.replace("[[CASCADED_VALUE]]", encodeURIComponent(cascadedValue));
                        if (url.indexOf("[[FIELD_VALUE]]") > 0)
                            url = url.replace("[[FIELD_VALUE]]", -1);
                    }

                    if (url.indexOf("[[CASCADED_VALUE]]") > 0 && cascadedValue === undefined)
                    {
                        if (e_jq[0].type != "select-multiple")
                        {
                            var lData = {};
                            lData.responseJSON = {};

                            lData.responseJSON.Id = value;
                            lData.responseJSON.Name = value;

                            this.bindDynamicControlData(e_jq, lData, value, fieldValue, fieldText);

                            return;
                        }
                    }


                    if (url.indexOf("[[") > -1 && url.indexOf("]]") > -1) {
                        //    var filter = url.substr(url.indexOf("[[") + 2, url.indexOf("]]") - url.indexOf("[[") - 2);
                        //    url = url.replace("[[" + filter + "]]", $("#" + filter).val());
                        var tmpFilters = url.substr(url.indexOf("[["));
                        var filters = tmpFilters.split("]]");
                        for (var i = 0; i < filters.length; i++) {
                            if (filters[i].indexOf("[[") > -1) {
                                var filter = filters[i].substr(filters[i].indexOf("[[")).replace("[[", "");
                                if (filter != undefined && filter != "")
                                    url = url.replace("[[" + filter + "]]", encodeURIComponent($("#" + filter).val()));
                            }
                        }
                    }

                    if (this.app != undefined && this.app != null) {
                        this.app.Notify("", true);
                        this.app.Log(scope, url, LOG_DEBUG);
                    }
                    $.ajax({
                        type: "get", url: url, context: this, crossDomain: false,
                        success: function (data, status, jqXHR) {
                            this.bindDynamicControlData(e_jq, jqXHR, value, fieldValue, fieldText);
                            //e_jq.attr("disabled", false);
                            if (this.app != undefined && this.app != null)
                                this.app.ClearNotifications();

                            if (this.app != undefined && this.app != null && this.app.CallbackFunctionsManager != null) {
                                if (e_jq.length > -0)
                                    this.app.CallbackFunctionsManager.CallCallbackFunction("DynamicContent###" + e_jq[0].id, data);
                            }
                        },
                        error: function (jqXHR, status, error) {
                            // debugger;
                            this.app.HandleError("", "", error);
                        },
                        complete: function (data) {
                            e_jq.attr("disabled", false);
                        }
                    });
                }
            }
        }

        this.bindDynamicControlData = function (control, data, value, fieldValue, fieldText) {
            var scope = "BindDynamicControlData";
            if (data != null && data != undefined && data.responseJSON != undefined) {

                var arrayData = [];
                if ((data.responseJSON.prop && data.responseJSON.prop.constructor === Array) || Array.isArray(data.responseJSON)) {
                    arrayData = data.responseJSON;
                }
                else {
                    if (fieldValue.indexOf(".") > -1) {
                        var propertyName = fieldValue.substr(0, fieldValue.indexOf("."));
                        fieldValue = fieldValue.substr(fieldValue.indexOf(".") + 1);
                        fieldText = fieldValue.replace(propertyName + ".", "");
                        eval("arrayData = data.responseJSON." + propertyName + ";");
                    }
                    else {
                        arrayData.push(data.responseJSON);
                    }
                }

                control.data("dynamicvalue", arrayData);
                if ($(control).attr("data-customcontrol") == undefined) {
                    if (control[0].tagName == "SELECT") {
                        $("<option value='" + emptyOptionValue + "'></option>").appendTo($(control));
                        var multivalues = [];
                        var values = [];
                        if ($(control)[0].multiple) {
                            if (typeof value === 'string')
                                values = value.split(",");
                            else if (value !== null)
                                values = value;
                        }
                        $.each(arrayData, function (i, item) {
                            var id = -1;
                            var text = "";
                            if (fieldValue != "")
                                eval("id = item." + fieldValue + ";");
                            else
                                id = item.id;
                            if (fieldText != "")
                                eval("text = item." + fieldText + ";");
                            else if (item.title !== undefined)
                                text = item.title;
                            else
                                text = item;

                            var isSelected = (value == id);
                            if ($(control)[0].multiple) {
                                for (var j = 0; j < values.length; j++) {
                                    if (values[j] == id) {
                                        isSelected = true;
                                        multivalues.push(id);
                                        break;
                                    }
                                }
                            }
                            $("<option value='" + id + "'" + (isSelected ? " selected" : "") + ">" + text + "</option>").appendTo($(control));
                            //console.log("<option value='" + id + "'" + (value == id ? " selected" : "") + ">" + text + "</option>");
                        });
                        // Force refresh select2
                        $(control).val($(control).val());
                        if (control.length > 0 && control[0].id != '') {
                            if ($(control)[0].multiple) {
                                //console.log("MV: " + multivalues.length);
                                try {
                                    $(control).select2('val', multivalues);
                                } catch (e) {
                                    console.log("Bind Dynamic Content MV error: " + e);
                                }
                            }
                            else {
                                try {
                                    $(control).select2('val', value);
                                } catch (e) {
                                    console.log("Bind Dynamic Content MV error: " + e);
                                }
                                //$("#select2-" + control[0].id + "-container").html($("#" + control[0].id + " option:selected").text());
                            }
                        }
                    }
                    else {
                        var textValue = "";
                        $.each(arrayData, function (i, item) {
                            var id = -1;
                            var text = "";
                            if (fieldValue != "")
                                eval("id = item." + fieldValue + ";");
                            else
                                id = item.id;
                            if (fieldText != "")
                                eval("text = item." + fieldText + ";");
                            else if (item.title !== undefined)
                                text = item.title;
                            else
                                text = item;
                            if (id == value)
                                textValue = text;
                        });
                        $(control).val(textValue);
                    }
                }
                else if ($(control).attr("data-customcontrol") == "checkbox") {
                    var libUi = this.app.LibUI;
                    var values = value.split(",");
                    $.each(arrayData, function (i, item) {
                        var id = -1;
                        var text = "";
                        if (fieldValue != "")
                            eval("id = item." + fieldValue + ";");
                        else
                            id = item.id;
                        if (fieldText != "")
                            eval("text = item." + fieldText + ";");
                        else if (item.title !== undefined)
                            text = item.title;
                        else
                            text = item;

                        var checked = false;
                        for (var i = 0; i < values.length; i++) {
                            if (values[i] === id) {
                                checked = true;
                                break;
                            }
                        }
                        var state = "";
                        if ($(control).attr("data-customstate") != undefined) {
                            state = $(control).attr("data-customstate");
                        }
                        if (libUi == 'Metro') {
                            var html = "<div class='checkboxlistitem'><label class='input-control checkbox'>" +
                                "<input type='checkbox' id='" + control[0].id.replace("PLACEHOLDER", "") + id + "'" + (checked ? " checked" : "") + " " + state + " />" +
                                "<span class='check'></span><span class='caption'>" + text + "</span>" +
                                "</label></div>";
                            $(html).appendTo($(control));
                        }
                        else {
                            var html = "<div class='checkboxlistitem'><label class=''>" +
                                "<input type='checkbox' id='" + control[0].id.replace("PLACEHOLDER", "") + id + "'" + (checked ? " checked" : "") + " " + state + " />" +
                                "<span class='check'></span><span class='caption'>" + text + "</span>" +
                                "</label></div>";
                            $(html).appendTo($(control));
                        }
                    });
                    $("input[id^='" + control[0].id.replace("PLACEHOLDER", "") + "']").on('change keyup', this, function (e) { e.data.onDynamicContentChanged(e.target, e.target.value); });
                }
            }
        }
    }

    // Class LookupController
    function LookupController() {
        this.prepareLookups = function () {
            var scope = "PrepareLookups";

            // Bind event handlers - this: the Button control
            $("button.button").on('click', this, function (e) {
                var fieldName = $(this).attr('data-field');
                if (fieldName != undefined) {
                    $('#' + fieldName).focus();
                    var dialog = $('#dialog' + fieldName).data('dialog');
                    if (!dialog.element.data('opened')) {
                        dialog.open();
                    }
                }
                return false;
            });
            $("button.btn").on('click', this, function (e) {
                var fieldName = $(this).attr('data-field');
                if (fieldName != undefined) {
                    $('#' + fieldName).focus();
                    var dialog = $('#dialog' + fieldName);
                    if (dialog != undefined)
                        dialog.modal('show');
                }
                return false;
            });
        }
    }

    // Class PopUpSearchController
    function PopUpSearchController() {
        var emptyOptionValue = "-1";
        this.app = null;

        this.prepareSearch = function () {
            var scope = "PreparePopUpSearch";

            $('#btnPopupSearch').on('click', this, function (e) {
                var fieldName = $(this).attr('data-field');
                if (fieldName != undefined) {
                    var resultTable = $('#tblPopupSearch' + fieldName);
                    var txtSearch = $('#txtPopupSearch' + fieldName);

                    if (resultTable.length > 0) {
                        resultTable.remove();
                    }
                    var libUi = e.data.app.LibUI;

                    if (libUi == 'Bootstrap') {
                        resultTable = $("<table id=\"tblPopupSearch" + fieldName + "\" class=\"table striped hovered border\"><thead><tr><th>Id</th><th>Title</th></tr></thead></table>");
                        resultTable.appendTo($('#dialogBody' + fieldName));
                    }
                    else {
                        resultTable = $("<table id=\"tblPopupSearch" + fieldName + "\" class=\"table striped hovered border\"><thead><tr><th>Id</th><th>Title</th></tr></thead></table>");
                        resultTable.appendTo($('#dialog' + fieldName));
                    }
                    txtSearch.attr("disabled", true);
                    e.data.bindDynamicSearch(resultTable, txtSearch, fieldName);
                }
            });
        }

        this.bindDynamicSearch = function (resultElem, searchElem, fieldName) {
            var scope = "BindDynamicSearch";
            var e_jq = $(searchElem);

            if (e_jq.length > 0) {
                var executeAjax = true;

                if (executeAjax) {
                    e_jq.html("");
                    var url = e_jq.attr("data-apiurl");
                    if (this.app != undefined && this.app != null) {
                        this.app.Notify("", true);
                        this.app.Log(scope, url, LOG_DEBUG);
                    }
                    $.ajax({
                        type: "get", url: url, context: this, crossDomain: false,
                        success: function (data, status, jqXHR) {
                            this.bindDynamicControlData(resultElem, jqXHR, fieldName);
                            if (this.app != undefined && this.app != null)
                                this.app.ClearNotifications();
                        },
                        error: function (jqXHR, status, error) {
                            this.app.HandleError("", "", error);
                        },
                        complete: function (data) {
                            e_jq.attr("disabled", false);
                        }
                    });
                }
            }
        }

        this.bindDynamicControlData = function (control, data, fieldName) {
            var scope = "BindDynamicControlData";
            if (data != null && data != undefined && data.responseJSON != undefined) {
                $("<tbody>").appendTo($(control));
                $.each(data.responseJSON, function (i, item) {
                    var id = item.id;
                    var text = item.title;
                    $("<tr style=\"cursor: pointer;\"><td class=\"rowID\" style=\"cursor: pointer;\">" + id + "</td><td class=\"rowText\" >" + text + "</td></tr>").appendTo($(control));
                });
                $("</tbody>").appendTo($(control));
            }

            $('#tblPopupSearch' + fieldName + ' tbody tr').on('click', this, function (e) {
                var title = $(this).find(".rowText").text();
                $('#' + fieldName).val(title);
                var libUi = e.data.app.LibUI;

                if (libUi == 'Bootstrap') {
                    var dialog = $('#dialog' + fieldName);
                    if (dialog != undefined)
                        dialog.modal('hide');
                }
                else {
                    var dialog = $('#dialog' + fieldName).data('dialog');
                    if (dialog.element.data('opened')) {
                        dialog.close();
                    }
                }
                $('#' + fieldName).focus();
            });
        }
    }

    // Class FileUploadController
    function FileUploadController() {
        this.app = null;

        this.prepareFileUpload = function () {
            var scope = "PrepareFileUpload";

            this.bindDynamicContent();

            var ctrls = $(".multipleupload");
            var cssClassDragDropContainer = "ajax-upload-dragdrop";
            var cssClassUploadButton = "ajax-file-upload";
            if (this.app != undefined) {
                if (this.app.LibUI == 'Bootstrap') {
                    cssClassDragDropContainer = "form-control";
                    cssClassUploadButton = "btn btn-primary";
                }
            }
            for (var i = 0; i < ctrls.length; i++) {
                var ctrl = $(ctrls[i]);

                if (ctrl.hasClass("readonly"))
                    continue;
                var postUrl = ctrl.attr("data-posturl");
                var allowMultipleUpload = (ctrl.attr("data-allowmulti") == "true" ? true : false);
                var allowDragDrop = (ctrl.attr("data-allowDragDrop") == "true" ? true : false);
                var formData = null;
                if (ctrl.attr("data-formData") != undefined && ctrl.attr("data-formData") != null && ctrl.attr("data-formData") != "") {
                    try
                    {
                        formData = JSON.parse(ctrl.attr("data-formData"));
                    }
                    catch(e)
                    {
                        var lData = ctrl.attr("data-formData").replace(/\\/g, "\\\\");
                        formData = JSON.parse(lData);
                    }
                }
                var msgDivId = ctrl[0].id + "-msg";

                ctrl.uploadFile({
                    //url: "/Requests/UploadFile?@this.Request.QueryString.ToString()",
                    url: postUrl,
                    multiple: allowMultipleUpload,
                    dragDrop: allowDragDrop,
                    dragdropWidth: "100%",
                    dragDropContainerClass: cssClassDragDropContainer,
                    dragDropStr: "<div class='ajax-upload-dragdrop-str'>Drag & Drop Files</div>",
                    uploadButtonClass: cssClassUploadButton,
                    fileName: "files",
                    formData: formData,
                    showDelete: true,
                    onSubmit: function (files) {
                        //$("#" + msgDivId).html($("#" + msgDivId).html() + "<br/>Submitting:" + JSON.stringify(files));
                        $("input[type='submit']").css({ "disabled": "disabled" });
                        app.SetFormsValidator();
                    },
                    onSuccess: function (files, data, xhr, pd) {
                        //$("#" + msgDivId).html($("#" + msgDivId).html() + "<br/>Success for: " + JSON.stringify(data));
                        $("input[type='submit']").css({ "disabled": "" });
                        app.SetFormsValidator();
                    },
                    onError: function (files, status, errMsg, pd) {
                        $("#" + msgDivId).html($("#" + msgDivId).html() + "<br/>Error for: " + JSON.stringify(files));
                        $("input[type='submit']").css({ "disabled": "" });
                        app.SetFormsValidator();
                    },
                    onCancel: function (files, pd) {
                        //$("#" + msgDivId).html($("#" + msgDivId).html() + "<br/>Canceled  files: " + JSON.stringify(files));
                        $("input[type='submit']").css({ "disabled": "" });
                        app.SetFormsValidator();
                    },
                    deleteCallback: function (data, pd) {
                        var temp = $.extend({}, formData);
                        temp.deletedFile = data;
                        $.post(postUrl, temp,
                            function (resp, textStatus, jqXHR) {
                                // Do nothing
                            });
                        pd.statusbar.hide();
                    }
                });
            }
            if (this.app != undefined) {
                this.app.Log(scope, 'Calling SetFormsValidator ' + (new Date()).toString(), LOG_DEBUG);
                setTimeout(app.SetFormsValidator, 500);
                // for slower machines
                setTimeout(app.SetFormsValidator, 1500);
            }
        }

        this.bindDynamicContent = function () {
            var scope = "BindDynamicContent";
            var e_jq = $(".multipleupload");

            if (e_jq.length > 0) {
                var executeAjax = true;

                if (executeAjax) {
                    //e_jq.html("");
                    var url = e_jq.attr("data-apiurl");
                    if (url.indexOf("[[") > -1 && url.indexOf("]]") > -1) {
                        var tmpFilters = url.substr(url.indexOf("[["));
                        var filters = tmpFilters.split("]]");
                        for (var i = 0; i < filters.length; i++) {
                            if (filters[i].indexOf("[[") > -1) {
                                var filter = filters[i].substr(filters[i].indexOf("[[")).replace("[[", "");
                                if (filter != undefined && filter != "")
                                    url = url.replace("[[" + filter + "]]", encodeURIComponent($("#" + filter).val()));
                            }
                        }
                    }

                    if (this.app != undefined && this.app != null) {
                        this.app.Notify("", true);
                        this.app.Log(scope, url, LOG_DEBUG);
                    }
                    $.ajax({
                        type: "get", url: url, context: this, crossDomain: false,
                        success: function (data, status, jqXHR) {
                            this.bindDynamicControlData(e_jq, jqXHR);

                            if (this.app != undefined && this.app != null)
                                this.app.ClearNotifications();

                            if (this.app != undefined && this.app != null && this.app.CallbackFunctionsManager != null) {
                                if (e_jq.length > -0)
                                    this.app.CallbackFunctionsManager.CallCallbackFunction("DynamicContent###" + e_jq[0].id, data);
                            }
                        },
                        error: function (jqXHR, status, error) {
                            this.app.HandleError("", "", error);
                        },
                        complete: function (data) {
                            e_jq.attr("disabled", false);
                        }
                    });
                }
            }
        }

        this.bindDynamicControlData = function (control, data) {
            var scope = "BindDynamicControlData";
            if (data != null && data != undefined && data.responseJSON != undefined) {
                if (data.responseJSON.Attachments != undefined && data.responseJSON.Attachments != null) {
                    var files = data.responseJSON.Attachments;
                    if (files.length > 0) {
                        if (this.app.LibUI == 'Bootstrap') {
                            for (var j = 0; j < control.length; j++) {
                                var html = "<div id='" + control[j].id + "Files' class='list-group' style='margin-top: 10px;'>";
                                //var html = "<ul class='fa-ul' style='margin-top: 10px;'>";
                                var readonly = $(control[j]).hasClass("readonly");
                                var allowDelete = ($(control[j]).attr("data-allowdelete") == "true" ? true : false);
                                for (var i = 0; i < files.length; i++) {
                                    if ("file" + files[i].FieldName == control[j].id) {
                                        //html = html + "<a href='" + files[i].AttachmentUrl + "' class='list-group-item' target='_new'><i class='fa " + this.getFileIcon(files[i].AttachmentFileName) + " fa-fw'></i> " + files[i].AttachmentFileName + "</a>";
                                        var deleteHtml = "";
                                        if (!readonly && allowDelete)
                                            deleteHtml = "<span class='pull-right text-muted small file-delete' data-itemurl='" + files[i].AttachmentUrl + "' data-itemuid='" + files[i].RequestUniqueId + "' data-controlid='hiddenData" + files[i].FieldName + "'>Delete<i class='fa fa-times fa-fw '></i></span>";
                                        html = html + "<a href='" + files[i].AttachmentUrl + "' class='list-group-item' target='_new'><i class='fa " + this.getFileIcon(files[i].AttachmentFileName) + " fa-fw'></i> " + files[i].AttachmentFileName + deleteHtml + "</a>";
                                        //html = html + "<li><i class='fa fa-file-" + this.getFileIcon(files[i].AttachmentFileName) + "-o fa-fw'></i> <a href='" + files[i].AttachmentUrl + "' target='_new'>" + files[i].AttachmentFileName + "</a></li>";
                                    }
                                }
                                html = html + "</div>";
                                //html = html + "</ul>";
                                $(control[j]).append(html);
                            }
                        }
                        else {
                            for (var j = 0; j < control.length; j++) {
                                var html = "<ul style='margin-top: 10px;'>";
                                for (var i = 0; i < files.length; i++) {
                                    if ("file" + files[i].FieldName == control[j].id) {
                                        html = html + "<li><a href='" + files[i].AttachmentUrl + "' target='_new'>" + files[i].AttachmentFileName + "</a></li>";
                                    }
                                }
                                html = html + "</ul>";
                                $(control[j]).append(html);
                            }
                        }
                        $(".file-delete").click(function () {
                            var url = $(this).attr("data-itemurl");
                            var uid = $(this).attr("data-itemuid");
                            var ctrlid = $(this).attr("data-controlid");
                            if ($("#" + ctrlid).val().length > 0)
                            {
                                var req = JSON.parse($("#" + ctrlid).val());
                                req.Attachments.push({ AttachmentUrl: url });
                                $("#" + ctrlid).val(JSON.stringify(req));
                            }
                            else
                                $("#" + ctrlid).val(JSON.stringify({ UniqueId: uid, Attachments: [ { AttachmentUrl: url } ] }));
                            $(this).parent().hide();
                            return false;
                        });
                    }
                }
            }
        }

        this.getFileIcon = function (fileName) {
            var extension = "";
            if (fileName.lastIndexOf(".") > -1) {
                extension = fileName.substr(fileName.lastIndexOf(".") + 1);
            }

            if (this.app.LibUI == 'Bootstrap') {
                switch (extension) {
                    case "xls":
                    case "xlsx":
                    case "xlsm":
                        return "fa-file-excel-o";
                    case "doc":
                    case "docx":
                        return "fa-file-word-o";
                    case "pdf":
                        return "fa-file-pdf-o";
                    case "txt":
                        return "fa-file-text-o";
                    case "zip":
                    case "rar":
                    case "7z":
                    case "cab":
                        return "fa-file-zip-o";
                    case "pdf":
                        return "fa-file-pdf-o";
                    default:
                        return "fa-file-o";
                }
            }
            else {

            }
        }

        this.addFileRow = function (fileName) {
        }
    }

    // Class PeoplePickerController
    function PeoplePickerController() {
        this.app = null;
        this.spHostUrl = null;
        this.spAppWebUrl = null;

        this.preparePeoplePicker = function () {
            var scope = "PreparePeoplePicker";

            try {
                this.spHostUrl = window.spHostUrl;
                this.spAppWebUrl = window.spAppWebUrl;

                var scriptbase = this.spHostUrl + "/_layouts/15/";
                $.getScript(scriptbase + "SP.RequestExecutor.js", //Get the cross-domain library
                    this.renderControls
                );
            } catch (e) {
                if (this.app != undefined && this.app != null) {
                    this.app.LogError(scope, "Fail to initialize Office controls.", e, LOG_ERROR);
                }
            }
        }

        this.renderControls = function () {
            // this: the jQuery Html Form from $.getScript function, use window object instead
            var scope = "RenderControls";
            try {
                if (typeof Office != 'undefined' && Office.Controls.Runtime != undefined) {
                    Office.Controls.Runtime.initialize({
                        sharePointHostUrl: window.spHostUrl,
                        appWebUrl: window.spAppWebUrl,
                    });
                    Office.Controls.Runtime.renderAll();

                    var controls = $(".custom-peoplepicker");
                    for (var i = 0; i < controls.length; i++) {
                        var v = $("#" + controls[i].id.replace("peoplePicker", "")).val();
                        if (typeof v != 'undefined' && v != undefined && v.length > 0) {
                            var pplPicker = controls[i]._officeControl;
                            if (v.indexOf("principalType") > -1) {
                                p = JSON.parse(v);
                                for (var i = 0; i < p.length; i++) {
                                    pplPicker.add(p[i], false);
                                }
                            }
                            else {
                                pplPicker.add(v, true);
                            }
                        }
                    }
                }
            } catch (e) {
                if (window.app != undefined && window.app != null) {
                    window.app.LogError(scope, "Fail to render Office controls.", e, window.app.LOG_ERROR);
                }
            }
        }

        this.onPeoplePickerChanged = function (pplPicker) {
            var users = [];
            for (var i = 0; i < pplPicker.selectedItems.length; i++) {
                users.push(pplPicker.selectedItems[i]);
            }
            if (pplPicker._root$p$0 != undefined && pplPicker._root$p$0 != null) {
                var hidden = $("#" + pplPicker._root$p$0.id.replace("peoplePicker", ""));
                hidden.val(JSON.stringify(users));
            }
        }

        this.bindDynamicContent = function () {
            var scope = "BindDynamicContent";
            var e_jq = $(".custom-peoplepicker");

            if (e_jq.length > 0) {
                for (var i = 0; i < e_jq.length; i++) {
                    var value = $(e_jq[i]).attr("data-value");
                    var data = null;
                    if (value != undefined && value != null && value != "") {
                        data = JSON.parse(value);
                    }
                    this.bindDynamicControlData(e_jq[i], data);
                }
            }
        }

        this.bindDynamicControlData = function (control, data) {
            var scope = "BindDynamicControlData";
            //if (data != null && data != undefined) {
                if (this.app.LibUI == 'Bootstrap') {
                    var html = "<div class='list-group' style='margin-top: 10px;'><span class='list-group-item'>";
                    if (data != null && data != undefined) {
                        for (var i = 0; i < data.length; i++) {
                            html = html + "<i class='fa fa-user fa-fw'></i> " + data[i].displayName + ((i == data.length - 1) ? "" : ",");
                        }
                    }
                    html = html + "</span></div>";
                    $(control).append(html);
                }
                else {
                    var html = "<ul style='margin-top: 10px;'>";
                    for (var i = 0; i < data.length; i++) {
                        html = html + "<li><span>" + data[i].displayName + "</span></li>";
                    }
                    html = html + "</ul>";
                    $(control).append(html);
                }
            //}
        }
    }

    // Class FunctionsCallManager
    function FunctionsCallManager() {
        var array = [];
        var functionNames = [];
        var enabled = true;

        this.Disable = function () {
            if (app != undefined)
                app.Log("FunctionsCallManager", "Disable", LOG_INFO);
            enabled = false;
        }

        this.PushFunction = function (func, name) {
            if (enabled) {
                var exists = false;
                if (name != undefined && name != null && name != "") {
                    for (var i = 0; i < functionNames.length; i++) {
                        if (functionNames[i] == name) {
                            exists = true;
                            break;
                        }
                    }
                }
                if (!exists) {
                    array.push(func);
                    functionNames.push(name);
                }
            }
            else
                func();
        }

        this.CallFunctions = function () {
            while (array.length) {
                var func = array.splice(0, 1)[0];
                if (app != undefined)
                    app.Log("FunctionsCallManager", "CallFunctions: " + func.toString(), LOG_INFO);
                func();
            }
            enabled = false;
        }

        this.CallCallbackFunction = function (name, data) {

            for (var i = 0; i < functionNames.length; i++) {
                if (functionNames[i] == name) {
                    var func = array[i];
                    func(name, data);
                }
            }
        }

        this.Reset = function () {
            array = [];
            functionNames = [];
        }
    }

    // Class App
    function App() {
        this.LogLevel = LOG_DEBUG;

        this.Hierarchy = new HierarchyController();
        this.Hierarchy.app = this;
        this.DynamicContent = new DynamicContentController();
        this.DynamicContent.app = this;
        this.Lookup = new LookupController();
        this.PopUpSearch = new PopUpSearchController();
        this.PopUpSearch.app = this;
        this.FileUpload = new FileUploadController();
        this.FileUpload.app = this;
        this.PeoplePicker = new PeoplePickerController();
        this.PeoplePicker.app = this;
        this.PeoplePicker.spHostUrl = window.spHostUrl;
        this.PeoplePicker.spAppWebUrl = window.spAppWebUrl;

        this.CallManager = new FunctionsCallManager();
        this.CallbackFunctionsManager = new FunctionsCallManager();

        this.LibUI = "";
        this.FormState = "";
        this.UseSP = false;

        this.SubscribeDefaultCallbacksForControllersInView = function () {
            this.CallManager.PushFunction(function () { app.Hierarchy.bindHierarchyData(); }, "app.Hierarchy.bindHierarchyData");
            this.CallManager.PushFunction(function () { app.DynamicContent.prepareContent(); }, "app.DynamicContent.prepareContent");
            this.CallManager.PushFunction(function () { app.Lookup.prepareLookups(); }, "app.Lookup.prepareLookups");
            this.CallManager.PushFunction(function () { app.PopUpSearch.prepareSearch(); }, "app.PopUpSearch.prepareSearch");
            this.CallManager.PushFunction(function () { app.FileUpload.bindDynamicContent(); }, "app.FileUpload.bindDynamicContent");
            if (this.UseSP) {
                this.CallManager.PushFunction(function () { app.PeoplePicker.bindDynamicContent(); }, "app.PeoplePicker.bindDynamicContent");
            }
        }

        this.SubscribeDefaultCallbacksForControllersInEdit = function () {
            this.CallManager.PushFunction(function () { app.Hierarchy.prepareLookups(); }, "app.Hierarchy.prepareLookups");
            this.CallManager.PushFunction(function () { app.DynamicContent.prepareContent(); }, "app.DynamicContent.prepareContent");
            this.CallManager.PushFunction(function () { app.Lookup.prepareLookups(); }, "app.Lookup.prepareLookups");
            this.CallManager.PushFunction(function () { app.PopUpSearch.prepareSearch(); }, "app.PopUpSearch.prepareSearch");
            this.CallManager.PushFunction(function () { app.FileUpload.prepareFileUpload(); }, "app.FileUpload.prepareFileUpload");
            if (this.UseSP) {
                this.CallManager.PushFunction(function () { app.PeoplePicker.preparePeoplePicker(); }, "app.PeoplePicker.preparePeoplePicker");
            }
        }

        this.Notify = function (message, keepOpen) {
            if (this.LibUI == "Metro") {
                var msg = message;
                if (message == "" || message == undefined)
                    msg = "Fetching data...";
                if ($.Notify != undefined) {
                    $.Notify({
                        caption: '',
                        content: msg,
                        keepOpen: keepOpen
                    });
                }
            }
            else {
                var dialog = $('#dialogLoading');
                if (dialog != undefined)
                    dialog.modal('show');
            }
        }

        this.ClearNotifications = function () {
            if (this.LibUI == "Metro") {
                $(".notify-container").remove();
            }
            else {
                var dialog = $('#dialogLoading');
                if (dialog != undefined)
                    dialog.modal('hide');
            }
        }

        this.Log = function (source, message, logLevel) {
            try {
                var doLog = true;
                if (logLevel != undefined) {
                    if (logLevel > this.LogLevel)
                        doLog = false;
                }
                if (doLog)
                    console.log(source + ": " + message);
            } catch (e) {

            }
        }

        this.LogError = function (source, message, exception, logLevel) {
            try {
                var doLog = true;
                if (logLevel != undefined) {
                    if (logLevel > this.LogLevel)
                        doLog = false;
                }
                if (doLog)
                    console.log(source + ": " + message + "\n Error: " + exception.message + "\n Stack: " + exception.stack);
            } catch (e) {
            }
        }

        this.HandleError = function (title, source, error) {
            // debugger;
            try {
                if (typeof (error) == "string")
                    alert(title + "\n\nSource: " + source + "\nError: " + error);
                else
                    alert(title + "\n\nSource: " + source + "\nError: " + error.message + "\n\nDetails: " + error.stack);
            } catch (e) {
            }
        }

        this.SetCookie = function (key, value) {
            var expires = new Date();
            expires.setTime(expires.getTime() + (1 * 24 * 60 * 60 * 1000));
            document.cookie = key + '=' + value + ';expires=' + expires.toUTCString();
        }

        this.GetCookie = function (key) {
            var keyValue = document.cookie.match('(^|;) ?' + key + '=([^;]*)(;|$)');
            return keyValue ? keyValue[2] : null;
        }

        this.GetQueryStringParam = function (key, defaultValue) {
            if (document.URL.indexOf('?') != -1) {
                key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
                var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
                var qs = regex.exec(window.location.href);
                if (qs == null)
                    return defaultValue;
                else
                    return decodeURIComponent(qs[1]);
            }
            return defaultValue;
        }

        this.GetRequestParam = function (key, defaultValue) {
            var value = this.GetQueryStringParam(key, '');
            if (value == '')
                value = this.GetCookie(key);
            return value;
        }

        this.RedirectHome = function () {
            document.location.href = "/?" + document.location.search;
        }

        this.ConfirmPageExit = function () {
            window.onbeforeunload = function (e) {
                var message = "Leave page without saving your changes?",
                e = e || window.event;
                // For IE and Firefox
                if (e) {
                    e.returnValue = message;
                }
                // For WebKit
                return message;
            };
        }

        this.AllowPageExit = function () {
            window.onbeforeunload = null;
        }

        this.AddAlert = function (text, icon, targetUrl, timespan, clear) {
            if (this.LibUI == "Metro") {
            }
            else {
                var html = '<a href="' + targetUrl + '"><div><i class="fa fa-' + icon + ' fa-fw"></i> ' + text + '<span class="pull-right text-muted small">' + timespan + '</span></div></a>';
                if (clear)
                    $(".dropdown-menu .dropdown-alerts").html(html);
                else
                    $(".dropdown-menu .dropdown-alerts").append(html);
            }
        }

        this.SetFormsValidator = function () {
            try {
                if ($.validator !== undefined) {
                    $.validator.setDefaults({ ignore: ".ignore, input[type='file'], :hidden" });
                    if (this.App === undefined)
                        this.Log("SetFormsValidator", "Forms: " + document.forms.length + " - " + (new Date()).toString(), LOG_DEBUG);
                    else
                        console.log("Forms: " + document.forms.length + " - " + (new Date()).toString());
                    //this.Log("SetFormsValidator", "Forms: " + document.forms.length + " - " + (new Date()).toString(), LOG_DEBUG);
                    for (var i = 0; i < document.forms.length; i++) {
                        $(document.forms[i]).validate();
                    }
                }
            } catch (ex) {
                if (app != undefined && app != null) {
                    app.HandleError("", "", ex);
                }
            }
        }

        this.ExecuteDefaultValidations = function (sender, formSelector, showAlert, isPartialValid) {
            var isValid = true;
            try {
                app.AllowPageExit();

                $(".error").removeClass("error");
                $(".has-error").removeClass("has-error");

                $("#UserCommand").val($(sender).val());
                if ($("#UserCommand").val() == "Cancel") {
                    app.RedirectHome();
                    return;
                }
                $("input[type='submit']").css("display", "none");
                $("input[type='button']").css("display", "none");

                //$("#ParentCategoryId").prop("disabled", false);

                //var isValid = $(formSelector).valid();

                var validations = $(formSelector).validate({ ignore: "input[type='file']" });
                isValid = (validations.errorList.length == 0);
                if (!isValid) {
                    for (var i = 0; i < validations.errorList.length; i++) {
                        $(validations.errorList[i].element).parent().addClass("error");
                    }
                }
                else {
                }
                // Force elements to get the aria-invalid attribute (if invalid)
                $.each($(formSelector)[0].elements, function (index, value) {
                    $(this).valid();
                });
                var invalids = $("input[aria-invalid='true']");
                isValid = (invalids.length == 0);
                if (!isValid) {
                    for (var i = 0; i < invalids.length; i++) {
                        var ctrl = $(invalids[i]);
                        ctrl.parent().addClass("error").addClass("has-error");
                    }
                }

                var transformedHiddens = $("textarea[aria-required='true'], select[aria-required='true'][data-role='select']");
                if (transformedHiddens.length > 0) {
                    for (var i = 0; i < transformedHiddens.length; i++) {
                        var ctrl = $(transformedHiddens[i]);
                        if (transformedHiddens[i].tagName.toLowerCase() == 'textarea') {
                            ctrl.next().addClass("error").addClass("has-error").css({ "border-color": "#A94442" });
                            isValid = false;
                        }
                        else if (transformedHiddens[i].tagName.toLowerCase() == 'select') {
                            if (ctrl.val() == null || ctrl.val().length == 0 || ctrl.val() == "-1") {
                                ctrl.parent().addClass("error").addClass("has-error");
                                isValid = false;
                            }
                        }
                        else {
                            ctrl.parent().addClass("error").addClass("has-error");
                            isValid = false;
                        }
                    }
                }

                if (window.CustomValidate != undefined) {
                    var errors = CustomValidate();
                    if (errors != undefined && errors.length > 0) {
                        for (var i = 0; i < errors.length; i++) {
                            var ctrl = $(errors[i].elementId);
                            ctrl.parent().addClass("error").addClass("has-error");
                            ctrl.popover({ content: errors[i].errorMessage, placement: 'top', trigger: 'focus' }).popover('show');
                        }
                        isValid = false;
                    }
                }
                if (isValid && !isPartialValid)
                    isValid = false;

                if (!isValid) {
                    if (showAlert)
                        alert("Validation errors occured.");
                    $("input[type='submit']").css("display", "");
                    $("input[type='button']").css("display", "");
                    window.scrollTo(0, 0);
                }
            } catch (ex) {
                isValid = false;
                //if (app != undefined && app != null) {
                //    app.HandleError("", "", ex);
                //}
                throw ex;
            }
            return isValid;
        }
    }
    return App;
})();
if (typeof console === "undefined") {
    console = {
        log: function () { },
        debug: function () { }
    };
}
