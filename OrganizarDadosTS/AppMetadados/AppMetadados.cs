using MetadataExtractor;
using OrganizarDadosTS.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrganizarDadosTS.AppMetadados
{
    public class AppMetadados
    {
        public async Task<Metadados> GetMetadadosAsync(FileInfo arquivo = null, string _arquivo = null)
        {
            return await Task.Run(() =>
             {
                 return GetMetadados(arquivo, _arquivo);
             });
        }

        public Metadados GetMetadados(FileInfo arquivo = null, string _arquivo = null)
        {
            var validacaoArquivo = _arquivo.ArquivoExiste();

            if ((arquivo != null && arquivo.Exists) || (validacaoArquivo.HasValue && validacaoArquivo.Value.arquivoExiste == true))
            {
                var arquivoTratado = arquivo == null ? validacaoArquivo.Value.arquivo : arquivo;

                var metadados = ImageMetadataReader.ReadMetadata(arquivoTratado.FullName)
                    .Where(x => x.Name == "IPTC" || x.Name == "Exif IFD0");

                var metadadosExtraidos = (from metadata in metadados

                                          where metadata.Name == "IPTC"
                                          select new
                                          {
                                              assunto = metadata.GetDescription(632),
                                              empresa = metadata.GetDescription(597),
                                              autor = metadata.GetDescription(592),
                                              marcas = metadata.GetDescription(537),
                                              titulo = metadata.GetDescription(517),
                                              empresa1 = metadata.GetDescription(634),
                                              data = metadados.FirstOrDefault(m => m.Name == "Exif IFD0").Tags.FirstOrDefault(t => t.Type == 306).Description
                                          }).FirstOrDefault();



                return new Metadados()
                {
                    Data = metadadosExtraidos.data.ToString().DataTratada(),
                    Assunto = metadadosExtraidos.assunto,
                    Autor = metadadosExtraidos.autor,
                    Empresa = metadadosExtraidos.empresa == null ? metadadosExtraidos.empresa1 : metadadosExtraidos.empresa,
                    Marcas = metadadosExtraidos.marcas,
                    Titulo = metadadosExtraidos.titulo
                };
            }

            return null;
        }


    }
}
