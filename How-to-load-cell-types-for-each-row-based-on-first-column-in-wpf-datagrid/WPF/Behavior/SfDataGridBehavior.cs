﻿using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Cells;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace SfDataGridDemo
{
    public class SfDataGridBehavior :Behavior<SfDataGrid>
    {
        SfDataGrid datagrid = null;
        protected override void OnAttached()
        {
            datagrid = this.AssociatedObject as SfDataGrid;
            datagrid.CellRenderers.Remove("Template");
            datagrid.CellRenderers.Add("Template", new GridCellDataTemplateRenderer());
            datagrid.Loaded += datagrid_Loaded;
        }

        private void datagrid_Loaded(object sender, RoutedEventArgs e)
        {
            this.datagrid.View.CollectionChanged += View_CollectionChanged;
            this.datagrid.View.RecordPropertyChanged += View_RecordPropertyChanged;
        }

        private void View_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems == null)
                return;
            var rowData = (e.OldItems[0] as Syncfusion.Data.RecordEntry).Data;
            var rowGenerator = this.datagrid.GetRowGenerator();
            var dataRowBase = rowGenerator.Items.FirstOrDefault(row => row.RowData == rowData);
            if (dataRowBase != null)
            {
                var propertyinfo = dataRowBase.GetType().GetProperty("VisibleColumns", BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Public);
                var columns = propertyinfo.GetValue(dataRowBase) as List<DataColumnBase>;
                foreach (var dataColumn in columns.Where(column => column.Renderer != null && column.GridColumn != null))
                {
                    dataColumn.UpdateBinding(rowData, false);
                }
            }
        }

        private void View_RecordPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "ProductName")
                return;
            var rowGenerator = this.datagrid.GetRowGenerator();

            var dataRowBase = rowGenerator.Items.FirstOrDefault(row => row.RowData == sender);
            if (dataRowBase != null)
            {
                var propertyinfo = dataRowBase.GetType().GetProperty("VisibleColumns", BindingFlags.Instance |
                            BindingFlags.NonPublic |
                            BindingFlags.Public);
                var columns = propertyinfo.GetValue(dataRowBase) as List<DataColumnBase>;
                foreach (var dataColumn in columns.Where(column => column.Renderer != null && column.GridColumn != null))
                {
                    dataColumn.UpdateBinding(sender, false);
                }
            }
        }
    }
}

