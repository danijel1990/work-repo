import { Component, Input, OnInit, ViewChild } from '@angular/core';
import {
  ChartOptions,
  ChartType,
  ChartDataSets,
  PluginServiceGlobalRegistration,
} from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { Label, BaseChartDirective } from 'ng2-charts';
import { InvoiceModel } from 'src/app/shared/models/invoice.model';

@Component({
  selector: 'app-invoice-chart',
  templateUrl: './invoice-chart.component.html',
  styleUrls: ['./invoice-chart.component.css'],
})
export class InvoiceChartComponent implements OnInit {
  @ViewChild(BaseChartDirective) chart: BaseChartDirective;
  @Input() chartData: Array<InvoiceModel>;
  emptyChartData = [
    {
      data: [20, 30],
      stack: '1',
      barPercentage: 1,
      order: 2,
      backgroundColor: [],
    },
  ];

  public barChartOptions: ChartOptions = {
    responsive: true,
    maintainAspectRatio: false,
    hover: {
      mode: null,
    },
    scales: {
      xAxes: {
        type: 'category',
        position: 'bottom',
        ticks: {},
      },
      yAxes: {
        type: 'linear',
        position: 'left',
      },
    },
    annotation: {
      // Defines when the annotations are drawn.
      // This allows positioning of the annotation relative to the other
      // elements of the graph.
      //
      // Should be one of: afterDraw, afterDatasetsDraw, beforeDatasetsDraw
      // See http://www.chartjs.org/docs/#advanced-usage-creating-plugins
      drawTime: 'beforeDatasetsDraw', // (default)

      // Double-click speed in ms used to distinguish single-clicks from
      // double-clicks whenever you need to capture both. When listening for
      // both click and dblclick, click events will be delayed by this
      // amount.
      dblClickSpeed: 350, // ms (default)

      // Array of annotation configuration objects
      // See below for detailed descriptions of the annotation options
      annotations: [],
    },
    plugins: {
      datalabels: {
        anchor: 'end',
        align: 'end',
      },
    },
  } as any;

  public barChartLabels: Label[] = [];
  public barChartType: ChartType = 'bar';
  public barChartLegend = true;
  public barChartPlugins = [<PluginServiceGlobalRegistration>pluginDataLabels];
  public barChartData: ChartDataSets[] = this.emptyChartData as ChartDataSets[];

  constructor() {}

  ngOnInit() {}

  ngOnChanges(changes) {
    if (changes.chartData) {
      this.refreshData();
    }
  }

  refreshData(): void {
    var data = JSON.parse(JSON.stringify(this.emptyChartData));
    this.barChartData = [...data];
  }
}
