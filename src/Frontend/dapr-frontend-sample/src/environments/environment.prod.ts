import { DiagLogLevel } from "@opentelemetry/api";

export const environment = {
  production: true,
  openTelemetryConfig: {
    commonConfig: {
      console: true, // Display trace on console
      production: false, // Send Trace with BatchSpanProcessor (true) or SimpleSpanProcessor (false)
      serviceName: 'instrumentation-example', // Service name send in trace
      probabilitySampler: '0.75', // 75% sampling
      logLevel: DiagLogLevel.ALL //ALL Log, DiagLogLevel is an Enum from @opentelemetry/api
    },
    zipkinConfig: {
      url: 'http://zipkin:9411/api/v2/spans'
    },
    // otelcolConfig: {
    //   url: 'http://localhost:55681/v1/trace', // URL of opentelemetry collector
    // },
    instrumentationConfig: {
      xmlHttpRequest: true,
      fetch: true,
      documentLoad: true,
    }
  }
};
