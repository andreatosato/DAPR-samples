{application, 'rabbitmq_prometheus', [
	{description, ""},
	{vsn, "3.8.16"},
	{id, "v3.8.15-3-gafd0d81"},
	{modules, ['prometheus_rabbitmq_core_metrics_collector','rabbit_prometheus_app','rabbit_prometheus_dispatcher','rabbit_prometheus_handler']},
	{registered, [rabbitmq_prometheus_sup]},
	{applications, [kernel,stdlib,rabbit,rabbitmq_management_agent,prometheus,rabbitmq_web_dispatch]},
	{mod, {rabbit_prometheus_app, []}},
	{env, [
	{return_per_object_metrics, false}
]}
]}.