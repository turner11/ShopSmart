/*
 * Infragistics.Web.ClientUI Grid Multi Headers 12.2.20122.2029
 *
 * Copyright (c) 2011-2012 Infragistics Inc.
 *
 * http://www.infragistics.com/
 *
 * Depends on:
 * Depends on:
 *  jquery-1.4.4.js
 *	jquery.ui.core.js
 *	jquery.ui.widget.js
 *	ig.ui.grid.framework.js
 *  ig.ui.shared.js
 *  ig.dataSource.js
 *	ig.util.js
 */
if(typeof(jQuery)!=="function"){throw new Error("jQuery is undefined")}(function(a){a.widget("ui.igGridMultiColumnHeaders",{css:{multiHeaderCell:"ui-iggrid-multiheader-cell"},options:{},_createWidget:function(){a.Widget.prototype._createWidget.apply(this,arguments)},_create:function(){},_renderingMultiColumnHeader:function(){this._renderHeaderColumns(this.grid._headerParent);this.grid._trigger(this.grid.events.headerRendered,null,{owner:this.grid,table:this.grid.headersTable()});this.grid._headerRenderCancel=false},_analyzeRowspanRows:function(g,e){var d,b,c=[],f=this.grid._maxLevel-e,h;for(d=0;d<g.length;d++){h=1;b=g[d];if(a.type(b.rowspan)==="string"){b.rowspan=parseInt(b.rowspan,10)}if(b.rowspan>0){h=b.rowspan}if(b.group!==undefined&&b.group!==null){c.push({group:b.group,level:e+h})}else{if(b.level===0){if(b.rowspan===null||b.rowspan===undefined||isNaN(b.rowspan)){if(f+1-b.level>0){b.rowspan=f+1-b.level}}}}if(this._rows[f]===undefined||this._rows[f]===null){this._rows[f]=[]}this._rows[f].push(b)}for(d=0;d<c.length;d++){this._analyzeRowspanRows(c[d].group,c[d].level)}},_renderRow:function(e,h,g){var d,f,b,c=a('<tr data-mch-level="'+g+'"></tr>').appendTo(e);for(f=0;f<h.length;f++){d=h[f];b=this._createHeaderColumnMarkup(d.headerText,d.colspan,d.key,d.level,d.identifier,d.rowspan);b.appendTo(c)}},_renderHeaderColumns:function(b){var c,h,k,e=this.grid.options.columns,f=e.length,j=this.grid._initialHiddenColumns,g=this.grid.element[0].id,d;this._arrayTargetRowspan=[];this._totalColumnsLength=b.find("colgroup col").length;d=b.find("thead");if(d.length>0){b=d.empty()}else{b=a("<thead></thead>").appendTo(b)}this._tr={};k=this.grid._oldCols;this._rows={};this._analyzeRowspanRows(k,0);for(h=this.grid._maxLevel;h>=0;h--){if(this._rows[h]!==null&&this._rows[h]!==undefined){this._renderRow(b,this._rows[h],h)}}for(h=0;h<f;h++){c=a("#"+g+"_"+e[h].key).data("columnIndex",h);c.data("data-mch-order",h);this.grid._headerCells.push(c)}if(j){for(h=0;h<j.length;h++){c=a("#"+g+"_"+j[h].key).css("display","none")}}},_createHeaderColumnMarkup:function(h,d,e,l,j,m){var f=this.grid,i,k=true,g=f.css.headerClass,c=a("<th></th>"),b;b=c.append('<span class="'+f.css.headerTextClass+'">'+h+"</span>").attr("role","rowheader").addClass(g);if(d>1){c.attr("colspan",d)}if(m>1){b.attr("rowspan",m)}if(e){b.attr("id",this.grid.element[0].id+"_"+e)}if(l===0){i=e;k=false;b.attr("data-isheadercell",true)}else{i=j;b.addClass(this.css.multiHeaderCell);b.attr("data-mch-id",j)}f._trigger(f.events.headerCellRendered,null,{owner:f,th:b,columnKey:i,isMultiColumnHeader:k});return b},getMultiColumnHeaders:function(){return this.grid._oldCols},destroy:function(){a.Widget.prototype.destroy.call(this);return this},_injectGrid:function(b,c){this.grid=b}});a.extend(a.ui.igGridMultiHeaders,{version:"12.2.20122.2029"})}(jQuery));