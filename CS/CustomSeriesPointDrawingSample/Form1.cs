﻿using CustomSeriesPointDrawingSample.Model;
using DevExpress.XtraCharts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace CustomSeriesPointDrawingSample {
    public partial class Form1 : Form {
        object trackedPointArgument;
        Dictionary<string, Image> photoCache = new Dictionary<string, Image>();

        #region #Constants
        const int borderSize = 5;
        const int scaledPhotoWidth = 48;
        const int scaledPhotoHeight = 51;
        // Width and height of scaled photo with border.
        const int totalWidth = 58;
        const int totalHeight = 61;

        // Rects required to create a custom legend series marker.
        static readonly Rectangle photoRect = new Rectangle(
                borderSize, borderSize,
                scaledPhotoWidth, scaledPhotoHeight);
        static readonly Rectangle totalRect = new Rectangle(
                0, 0,
                totalWidth, totalHeight);
        #endregion

        public Form1() {
            InitializeComponent();
        }

        #region #ChartPreparation
        private void Form1_Load(object sender, EventArgs e) {
            chart.CustomDrawSeriesPoint += OnCustomDrawSeriesPoint;
            chart.BoundDataChanged += OnBoundDataChanged;
            chart.ObjectHotTracked += OnObjectHotTracked;

            using (var context = new NwindDbContext()) {
                chart.DataSource = PrepareDataSource(context.Orders);
                InitPhotoCache(context.Employees);
            }
            chart.SeriesDataMember = "Year";
            chart.SeriesTemplate.ArgumentDataMember = "Employee";
            chart.SeriesTemplate.ValueDataMembers.AddRange("Value");

            chart.SeriesTemplate.ToolTipPointPattern = "{S}: {A} ({VP:P})";
            chart.SeriesTemplate.SeriesPointsSorting = SortingMode.Ascending;
        }
        #endregion

        #region #AutogeneratedSeriesModifying
        private void OnBoundDataChanged(object sender, EventArgs e) {
            if (chart.Series.Count <= 1) return;
            for (int i = 1; i < chart.Series.Count; ++i)
                chart.Series[i].ShowInLegend = false;
        }
        #endregion

        #region #CustomPointDrawing
        private void OnCustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e) {
            // Design a series marker image.
            Bitmap image = new Bitmap(totalWidth, totalHeight);
            bool isSelected = trackedPointArgument != null && e.SeriesPoint.Argument.Equals(trackedPointArgument);

            using (Graphics graphics = Graphics.FromImage(image)) {
                Brush fillBrush = isSelected ?
                    (Brush)new HatchBrush(
                            HatchStyle.DarkDownwardDiagonal, 
                            e.LegendDrawOptions.Color, 
                            e.LegendDrawOptions.ActualColor2) :
                    (Brush)new SolidBrush(e.LegendDrawOptions.Color);
                graphics.FillRectangle(fillBrush, totalRect);
                Image photo;
                if (photoCache.TryGetValue(e.SeriesPoint.Argument, out photo))
                    graphics.DrawImage(photo, photoRect);
            }
            e.LegendMarkerImage = image;
            e.DisposeLegendMarkerImage = true;

            PieDrawOptions options = e.SeriesDrawOptions as PieDrawOptions;
            if (isSelected && options != null) {
                options.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Hatch;
                ((HatchFillOptions)options.FillStyle.Options).HatchStyle = HatchStyle.DarkDownwardDiagonal;
            }
        }
        #endregion

        private void OnObjectHotTracked(object sender, HotTrackEventArgs e) {
            trackedPointArgument = e.HitInfo.InSeriesPoint ? e.HitInfo.SeriesPoint.Argument : null;
            chart.Invalidate();
        }

        void InitPhotoCache(IEnumerable<Employee> employees) {
            photoCache.Clear();
            foreach (var employee in employees) {
                MemoryStream stream = new MemoryStream(employee.Photo);
                if (!photoCache.ContainsKey(employee.FullName))
                    photoCache.Add(employee.FullName, Image.FromStream(stream));
            }
        }

        List<SalesPoint> PrepareDataSource(IEnumerable<Order> orders) {
            var query = from o in orders
                        group o by new {
                            Year = o.OrderDate.Year,
                            Employee = o.Employee.FirstName + " " + o.Employee.LastName
                        }
                        into g
                        select new {
                            Employee = g.Key.Employee,
                            Year = g.Key.Year,
                            Values = g.Select(o => o.Freight.HasValue ? o.Freight.Value : 0)
                        };

            List<SalesPoint> points = new List<SalesPoint>();
            foreach (var item in query) {
                points.Add(new SalesPoint {
                    Employee = item.Employee,
                    Year = item.Year,
                    Value = item.Values.Aggregate((d1, d2) => d1 + d2)
                });
            }
            return points;
        }
    }
}

class SalesPoint {
    public string Employee { get; set; }
    public int Year { get; set; }
    public decimal Value { get; set; }
}
