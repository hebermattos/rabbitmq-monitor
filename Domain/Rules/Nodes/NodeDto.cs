namespace rabbitmq.monitor
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Application
    {
        public string name { get; set; }
        public string description { get; set; }
        public string version { get; set; }
    }

    public class AuthMechanism
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
    }

    public class ChannelClosedDetails
    {
        public double rate { get; set; }
    }

    public class ChannelCreatedDetails
    {
        public double rate { get; set; }
    }

    public class ClusterLink
    {
        public Stats stats { get; set; }
        public string name { get; set; }
        public string peer_addr { get; set; }
        public int peer_port { get; set; }
        public string sock_addr { get; set; }
        public int sock_port { get; set; }
        public int recv_bytes { get; set; }
        public int send_bytes { get; set; }
    }

    public class ConnectionClosedDetails
    {
        public double rate { get; set; }
    }

    public class ConnectionCreatedDetails
    {
        public double rate { get; set; }
    }

    public class Context
    {
        public string description { get; set; }
        public string path { get; set; }
        public string cowboy_opts { get; set; }
        public string port { get; set; }
        public string protocol { get; set; }
    }

    public class ContextSwitchesDetails
    {
        public double rate { get; set; }
    }

    public class DiskFreeDetails
    {
        public double rate { get; set; }
    }

    public class ExchangeType
    {
        public string name { get; set; }
        public string description { get; set; }
        public bool enabled { get; set; }
    }

    public class FdUsedDetails
    {
        public double rate { get; set; }
    }

    public class GcBytesReclaimedDetails
    {
        public double rate { get; set; }
    }

    public class GcNumDetails
    {
        public double rate { get; set; }
    }

    public class IoReadAvgTimeDetails
    {
        public double rate { get; set; }
    }

    public class IoReadBytesDetails
    {
        public double rate { get; set; }
    }

    public class IoReadCountDetails
    {
        public double rate { get; set; }
    }

    public class IoReopenCountDetails
    {
        public double rate { get; set; }
    }

    public class IoSeekAvgTimeDetails
    {
        public double rate { get; set; }
    }

    public class IoSeekCountDetails
    {
        public double rate { get; set; }
    }

    public class IoSyncAvgTimeDetails
    {
        public double rate { get; set; }
    }

    public class IoSyncCountDetails
    {
        public double rate { get; set; }
    }

    public class IoWriteAvgTimeDetails
    {
        public double rate { get; set; }
    }

    public class IoWriteBytesDetails
    {
        public double rate { get; set; }
    }

    public class IoWriteCountDetails
    {
        public double rate { get; set; }
    }

    public class MemUsedDetails
    {
        public double rate { get; set; }
    }

    public class MetricsGcQueueLength
    {
        public int connection_closed { get; set; }
        public int channel_closed { get; set; }
        public int consumer_deleted { get; set; }
        public int exchange_deleted { get; set; }
        public int queue_deleted { get; set; }
        public int vhost_deleted { get; set; }
        public int node_node_deleted { get; set; }
        public int channel_consumer_deleted { get; set; }
    }

    public class MnesiaDiskTxCountDetails
    {
        public double rate { get; set; }
    }

    public class MnesiaRamTxCountDetails
    {
        public double rate { get; set; }
    }

    public class MsgStoreReadCountDetails
    {
        public double rate { get; set; }
    }

    public class MsgStoreWriteCountDetails
    {
        public double rate { get; set; }
    }

    public class NodeDto
    {
        public List<object> partitions { get; set; }
        public string os_pid { get; set; }
        public int fd_total { get; set; }
        public int sockets_total { get; set; }
        public object mem_limit { get; set; }
        public bool mem_alarm { get; set; }
        public int disk_free_limit { get; set; }
        public bool disk_free_alarm { get; set; }
        public int proc_total { get; set; }
        public string rates_mode { get; set; }
        public int uptime { get; set; }
        public int run_queue { get; set; }
        public int processors { get; set; }
        public List<ExchangeType> exchange_types { get; set; }
        public List<AuthMechanism> auth_mechanisms { get; set; }
        public List<Application> applications { get; set; }
        public List<Context> contexts { get; set; }
        public List<string> log_files { get; set; }
        public string db_dir { get; set; }
        public List<string> config_files { get; set; }
        public int net_ticktime { get; set; }
        public List<string> enabled_plugins { get; set; }
        public string mem_calculation_strategy { get; set; }
        public RaOpenFileMetrics ra_open_file_metrics { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public bool running { get; set; }
        public int mem_used { get; set; }
        public MemUsedDetails mem_used_details { get; set; }
        public int fd_used { get; set; }
        public FdUsedDetails fd_used_details { get; set; }
        public int sockets_used { get; set; }
        public SocketsUsedDetails sockets_used_details { get; set; }
        public int proc_used { get; set; }
        public ProcUsedDetails proc_used_details { get; set; }
        public object disk_free { get; set; }
        public DiskFreeDetails disk_free_details { get; set; }
        public int gc_num { get; set; }
        public GcNumDetails gc_num_details { get; set; }
        public long gc_bytes_reclaimed { get; set; }
        public GcBytesReclaimedDetails gc_bytes_reclaimed_details { get; set; }
        public int context_switches { get; set; }
        public ContextSwitchesDetails context_switches_details { get; set; }
        public int io_read_count { get; set; }
        public IoReadCountDetails io_read_count_details { get; set; }
        public int io_read_bytes { get; set; }
        public IoReadBytesDetails io_read_bytes_details { get; set; }
        public double io_read_avg_time { get; set; }
        public IoReadAvgTimeDetails io_read_avg_time_details { get; set; }
        public int io_write_count { get; set; }
        public IoWriteCountDetails io_write_count_details { get; set; }
        public int io_write_bytes { get; set; }
        public IoWriteBytesDetails io_write_bytes_details { get; set; }
        public double io_write_avg_time { get; set; }
        public IoWriteAvgTimeDetails io_write_avg_time_details { get; set; }
        public int io_sync_count { get; set; }
        public IoSyncCountDetails io_sync_count_details { get; set; }
        public double io_sync_avg_time { get; set; }
        public IoSyncAvgTimeDetails io_sync_avg_time_details { get; set; }
        public int io_seek_count { get; set; }
        public IoSeekCountDetails io_seek_count_details { get; set; }
        public double io_seek_avg_time { get; set; }
        public IoSeekAvgTimeDetails io_seek_avg_time_details { get; set; }
        public int io_reopen_count { get; set; }
        public IoReopenCountDetails io_reopen_count_details { get; set; }
        public int mnesia_ram_tx_count { get; set; }
        public MnesiaRamTxCountDetails mnesia_ram_tx_count_details { get; set; }
        public int mnesia_disk_tx_count { get; set; }
        public MnesiaDiskTxCountDetails mnesia_disk_tx_count_details { get; set; }
        public int msg_store_read_count { get; set; }
        public MsgStoreReadCountDetails msg_store_read_count_details { get; set; }
        public int msg_store_write_count { get; set; }
        public MsgStoreWriteCountDetails msg_store_write_count_details { get; set; }
        public int queue_index_write_count { get; set; }
        public QueueIndexWriteCountDetails queue_index_write_count_details { get; set; }
        public int queue_index_read_count { get; set; }
        public QueueIndexReadCountDetails queue_index_read_count_details { get; set; }
        public int connection_created { get; set; }
        public ConnectionCreatedDetails connection_created_details { get; set; }
        public int connection_closed { get; set; }
        public ConnectionClosedDetails connection_closed_details { get; set; }
        public int channel_created { get; set; }
        public ChannelCreatedDetails channel_created_details { get; set; }
        public int channel_closed { get; set; }
        public ChannelClosedDetails channel_closed_details { get; set; }
        public int queue_declared { get; set; }
        public QueueDeclaredDetails queue_declared_details { get; set; }
        public int queue_created { get; set; }
        public QueueCreatedDetails queue_created_details { get; set; }
        public int queue_deleted { get; set; }
        public QueueDeletedDetails queue_deleted_details { get; set; }
        public List<ClusterLink> cluster_links { get; set; }
        public MetricsGcQueueLength metrics_gc_queue_length { get; set; }
    }

    public class ProcUsedDetails
    {
        public double rate { get; set; }
    }

    public class QueueCreatedDetails
    {
        public double rate { get; set; }
    }

    public class QueueDeclaredDetails
    {
        public double rate { get; set; }
    }

    public class QueueDeletedDetails
    {
        public double rate { get; set; }
    }

    public class QueueIndexReadCountDetails
    {
        public double rate { get; set; }
    }

    public class QueueIndexWriteCountDetails
    {
        public double rate { get; set; }
    }

    public class RaOpenFileMetrics
    {
        public int ra_log_wal { get; set; }
        public int ra_log_segment_writer { get; set; }
    }

    public class RecvBytesDetails
    {
        public double rate { get; set; }
    }

    public class SendBytesDetails
    {
        public double rate { get; set; }
    }

    public class SocketsUsedDetails
    {
        public double rate { get; set; }
    }

    public class Stats
    {
        public int send_bytes { get; set; }
        public SendBytesDetails send_bytes_details { get; set; }
        public int recv_bytes { get; set; }
        public RecvBytesDetails recv_bytes_details { get; set; }
    }



}