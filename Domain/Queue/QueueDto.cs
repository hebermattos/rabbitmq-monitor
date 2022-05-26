// Root myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(myJsonResponse);
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

    public class Arguments
    {
        [JsonProperty("x-queue-type")]
        public string XQueueType { get; set; }
    }

    public class BackingQueueStatus
    {
        public double avg_ack_egress_rate { get; set; }
        public double avg_ack_ingress_rate { get; set; }
        public double avg_egress_rate { get; set; }
        public double avg_ingress_rate { get; set; }
        public List<object> delta { get; set; }
        public int len { get; set; }
        public string mode { get; set; }
        public int next_deliver_seq_id { get; set; }
        public int next_seq_id { get; set; }
        public int q1 { get; set; }
        public int q2 { get; set; }
        public int q3 { get; set; }
        public int q4 { get; set; }
        public string target_ram_count { get; set; }
        public int version { get; set; }
    }

    public class EffectivePolicyDefinition
    {
    }

    public class GarbageCollection
    {
        public int fullsweep_after { get; set; }
        public int max_heap_size { get; set; }
        public int min_bin_vheap_size { get; set; }
        public int min_heap_size { get; set; }
        public int minor_gcs { get; set; }
    }

    public class MessagesDetails
    {
        public double rate { get; set; }
    }

    public class MessagesReadyDetails
    {
        public double rate { get; set; }
    }

    public class MessagesUnacknowledgedDetails
    {
        public double rate { get; set; }
    }

    public class ReductionsDetails
    {
        public double rate { get; set; }
    }

    public class QueueDto
    {
        public Arguments arguments { get; set; }
        public bool auto_delete { get; set; }
        public BackingQueueStatus backing_queue_status { get; set; }
        public int consumer_capacity { get; set; }
        public int consumer_utilisation { get; set; }
        public int consumers { get; set; }
        public bool durable { get; set; }
        public EffectivePolicyDefinition effective_policy_definition { get; set; }
        public bool exclusive { get; set; }
        public object exclusive_consumer_tag { get; set; }
        public GarbageCollection garbage_collection { get; set; }
        public object head_message_timestamp { get; set; }
        public DateTime idle_since { get; set; }
        public int memory { get; set; }
        public int message_bytes { get; set; }
        public int message_bytes_paged_out { get; set; }
        public int message_bytes_persistent { get; set; }
        public int message_bytes_ram { get; set; }
        public int message_bytes_ready { get; set; }
        public int message_bytes_unacknowledged { get; set; }
        public int messages { get; set; }
        public MessagesDetails messages_details { get; set; }
        public int messages_paged_out { get; set; }
        public int messages_persistent { get; set; }
        public int messages_ram { get; set; }
        public int messages_ready { get; set; }
        public MessagesReadyDetails messages_ready_details { get; set; }
        public int messages_ready_ram { get; set; }
        public int messages_unacknowledged { get; set; }
        public MessagesUnacknowledgedDetails messages_unacknowledged_details { get; set; }
        public int messages_unacknowledged_ram { get; set; }
        public string name { get; set; }
        public string node { get; set; }
        public object operator_policy { get; set; }
        public object policy { get; set; }
        public object recoverable_slaves { get; set; }
        public int reductions { get; set; }
        public ReductionsDetails reductions_details { get; set; }
        public object single_active_consumer_tag { get; set; }
        public string state { get; set; }
        public string type { get; set; }
        public string vhost { get; set; }
    }

