import { Component, Input, OnInit, ViewChild } from '@angular/core';
import {
  ChartOptions,
  ChartType,
  ChartDataSets,
  PluginServiceGlobalRegistration,
} from 'chart.js';
import * as pluginDataLabels from 'chartjs-plugin-datalabels';
import { getDate } from 'date-fns';
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
      data: [],
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
      xAxes: [{
        type: 'category',
        position: 'bottom',

      }],
      yAxes: [
        {
          type: 'linear',
          position: 'left',
          ticks: {
            max: 100
          },
        }
      ],
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
  public barChartLegend = false;
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
    const calculatedData = [];
    const max = (calculatedData.map(r => r.totalPrice).sort((a,b) => b - a)[0] || 0) + 20;
    var data = [
      {
        data: calculatedData.map(r => r.totalPrice),
        stack: '1',
        barPercentage: 1,
        order: 2,
        backgroundColor: [],
      },
    ];
    this.barChartOptions = {...this.barChartOptions, scales: {
      xAxes: [{
        type: 'category',
        position: 'bottom',

      }],
      yAxes: [
        {
          type: 'linear',
          position: 'left',
          ticks: {
            max: max
          },
        }
      ],
    },};
    this.barChartLabels = calculatedData.map(r => getDate(new Date(r.invoiceDate)).toString());
    this.barChartData = [...data];
  }
}
