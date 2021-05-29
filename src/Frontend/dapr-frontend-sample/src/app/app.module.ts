import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AccessDaprComponent } from './access-dapr/access-dapr.component';
import { OpenTelemetryInterceptorModule, OtelColExporterModule, CompositePropagatorModule, OtelWebTracerModule, ZipkinExporterModule } from '@jufab/opentelemetry-angular-interceptor';
import { DiagLogLevel } from '@opentelemetry/api';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    AccessDaprComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    //Insert module OpenTelemetryInterceptorModule with configuration, HttpClientModule is used for interceptor
    OpenTelemetryInterceptorModule.forRoot(environment.openTelemetryConfig),
    //Insert OtelCol exporter module
    OtelColExporterModule,
    //Insert propagator module
    CompositePropagatorModule,
    OtelWebTracerModule.forRoot(environment.openTelemetryConfig),
    ZipkinExporterModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
