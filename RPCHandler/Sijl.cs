using Grpc.Net.Client;
using Grpc.Net.Client.Web;

namespace RPCHandler;

public class SijlHandler
{
    public Sijl.Sijl.SijlClient Client { get; set; }

    public SijlHandler()
    {
        var builder = new UriBuilder();
        var channel = GrpcChannel.ForAddress(builder.Uri);
        Client = new Sijl.Sijl.SijlClient(channel);
    }
}