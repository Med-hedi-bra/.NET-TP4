using System.Text;

namespace StudentPortal.Controllers
{
    public sealed class Eng : IEng
    {
        private Eng() { }
        private static readonly Lazy<Eng> instance = new Lazy<Eng>(() => new Eng());
        public static Eng GetInstance { get { return instance.Value; } }
        public void EngException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}
