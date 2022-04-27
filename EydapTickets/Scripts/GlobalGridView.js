(function ( $ ) {
    'use strict';

    // TODO: Handled polyfills
    if (!Array.prototype.includes) {
        Object.defineProperty(Array.prototype, "includes", {
            enumerable: false,
            value: function(obj) {
                var newArr = this.filter(function(el) {
                    return el === obj;
                });
                return newArr.length > 0;
            }
        });
    }

    if (!window.triggerResize) {
        window.triggerResize = function() {
            if (navigator.userAgent.indexOf('MSIE') !== -1 || navigator.appVersion.indexOf('Trident/') > 0) {
                var resizeEvent = this.document.createEvent('UIEvents');
                resizeEvent.initUIEvent('resize', true, false, this, 0);
                this.dispatchEvent(resizeEvent);
            } else {
                this.dispatchEvent(new Event('resize'));
            }
        };
    }

    var gridViewInViewPort;
    var gridViewsAttachedToResize = [];

    window.GlobalGridView_Init = function(s, e) {
        var gridView = s;
        gridViewInViewPort = gridView.name;
        gridView.GetMainElement().classList.add("dxGridView_gvAutoResize");
        if (gridViewsAttachedToResize.includes(gridView.name) === false) {
            //ASPxClientUtils.AttachEventToElement(window, "resize", $.throttle(100, function () {
            $(window).resize($.throttle(100, function() {
                if (gridView.name === gridViewInViewPort) {
                    GlobalGridView_AdjustSize(gridView);
                }
            }));
            gridViewsAttachedToResize.push(gridView.name);
        }
    };

    window.GlobalGridView_EndCallback = function(s, e) {
        var gridView = s;
        if (gridView.name === gridViewInViewPort) {
            GlobalGridView_AdjustSize(s);
        }
    };

    window.GlobalGridView_AdjustSize = function(gridView) {

        // Start with the client height
        var targetHeight = document.documentElement.clientHeight;

        // Account for header pane
        var headerPane = window.HeaderPane;
        if (typeof(headerPane) !== "undefined") {
            targetHeight -= headerPane.GetHeight();
        }

        // Account for criteria panel
        var criteriaPanel = window.CriteriaPanel;
        if (typeof(criteriaPanel) !== "undefined") {
            targetHeight -= criteriaPanel.GetHeight();
        }

        // Update height if changed
        var originalHeight = gridView.GetHeight();
        if  (originalHeight !== targetHeight) {
            gridView.SetHeight(-1); // Use this to force the update
            gridView.SetHeight(targetHeight);
        }
    }

}( jQuery ));