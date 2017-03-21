using System.ServiceProcess;

namespace SWSPFetchTrackService
{
    public partial class SWSPFetchTrackService : ServiceBase
    {
        public SWSPFetchTrackService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
