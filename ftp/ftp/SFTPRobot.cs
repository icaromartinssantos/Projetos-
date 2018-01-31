using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using cfg = ftp.configHelper;
using System.IO;

namespace ftp
{
    public class SFTPRobot : IFTPRobot
    {
        //public SftpClient client { get; set; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public void ListarDiretorioLocalEEnviar()
        {
            int i = 1;
            Console.Write("Listando o diretório "+ cfg.LocalUploadPending + "\n");
            //Directory trabalha com múltiplos arquivos e junto com GetFiles ele retorna uma array de string onde abrange o caminho do arquivo que está no diretório informado
            var arquivoAMover = Directory.GetFiles(cfg.LocalUploadPending);

            //Verifica se o array possui algum registro
            if(arquivoAMover.Count() > 0)
            {

                foreach(var arquivo in arquivoAMover)
                {
                    //Verifica se o arquivo existe
                    if (!Directory.Exists(arquivo))
                    {
                        Console.Write("movendo " + i + "de" + arquivoAMover.Count() + "\n");
                        SubirArquivoEMoverParaOk(arquivo);
                        i++;

                    }
                }

            }
            else
            {
                Console.Write("Não há arquivos para serem movidos.\n");
            }

        }

        private void SubirArquivoEMoverParaOk(string arquivo)
        {
            //Pega as informações do arquivo
            var info = new FileInfo(arquivo);
            //Cria o caminho destino do arquivo
            var destinoLocal = Path.Combine(cfg.LocalUploadOk, info.Name);
            //Move o arquivo para o caminho destinado
            File.Move(arquivo, destinoLocal);

        }
    }
}
