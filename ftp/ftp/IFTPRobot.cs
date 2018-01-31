using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ftp
{
    public interface IFTPRobot: IDisposable
    {
        //http://www.nudoq.org/#!/Packages/SSH.NET/Renci.SshNet/SftpClient 
        //SftpClient client { get; set; }

       
        void ListarDiretorioLocalEEnviar();

    }
}
