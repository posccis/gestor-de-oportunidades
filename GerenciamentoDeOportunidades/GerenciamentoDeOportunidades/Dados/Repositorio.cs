using GerenciamentoDeOportunidades.Dados;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace GerenciamentoDeOportunidades
{
    public class Repositorio
    {
        private OportunidadesContext Dbcontext;

        #region Construtores
        public Repositorio() : base()
        {

        }

        public Repositorio(OportunidadesContext dbcontext)
        {
            Dbcontext = dbcontext;
        }
        #endregion Construtores

        #region Salvar 

        public bool Salvar()
        {

            try
            {

                return Dbcontext.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Salvar

        #region Métodos de Inserção
        public bool InserirUsuario(Usuario usuario)
        {
            try
            {

                EntityEntry<Usuario> usuario1 = Dbcontext.usuarios.Add(usuario);

                return usuario1 != null;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InserirOportunidade(Oportunidade oportunidade)
        {
            try
            {
                EntityEntry<Oportunidade> opo = Dbcontext.oportunidades.Add(oportunidade);
                return opo != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Métodos de Inserção

        #region Métodos de Obtenção
        public Usuario SelecionarUsuarioPorRegiao(int regioesEnum)
        {
            Random rnd = new Random();
            Usuario[] usuariosPorRegiao = new Usuario[] { };
            Oportunidade[] oportunidadesPorRegiao = new Oportunidade[] { };
            Usuario[] usuariosSemOportunidades = new Usuario[] { };
            Usuario ultimoUsuario = null;
            Usuario usuario = new Usuario();
            try
            {
                usuariosSemOportunidades = Dbcontext.usuarios.Where(a => a.Oportunidades.ToArray().Length <= 0 && (int)a.Regiao == regioesEnum).ToArray();
                oportunidadesPorRegiao = Dbcontext.oportunidades.FromSqlRaw("SELECT opo.* FROM OPORTUNIDADES as OPO, USUARIOS AS usu WHERE opo.UsuarioEmailId = usu.EmailId AND usu.Regiao = {0}", regioesEnum).ToArray();
                
                usuariosPorRegiao = Dbcontext.usuarios.Where(u => (int)u.Regiao == regioesEnum).ToArray();

                if (usuariosSemOportunidades.Length > 0)
                {
                    if (Dbcontext.oportunidades.ToArray().Length > 0)
                    {
                        if (usuariosPorRegiao.Length > 1)
                        {
                            ultimoUsuario = Dbcontext.usuarios.Where(a => a.Oportunidades.Contains(oportunidadesPorRegiao[oportunidadesPorRegiao.Length - 1]) && (int)a.Regiao == regioesEnum).ToArray().Last();
                            usuariosPorRegiao = Dbcontext.usuarios.Where(u => u != ultimoUsuario && (int)u.Regiao == regioesEnum).ToArray();
                            usuario = usuariosPorRegiao[rnd.Next(usuariosPorRegiao.Length)];
                            return usuario;
                        }


                    }
                    if (usuariosPorRegiao.Length > 0)
                    {
                        usuario = usuariosPorRegiao.First();
                    }
                    

                }
                else
                {
                    if(usuariosPorRegiao.Length > 0)
                    {
                        usuario = usuariosPorRegiao.First();
                    }
                    
                }



                #region Código de FILA comentado
                //if (usuariosList.Length == 0)
                //{
                //    usuario = Dbcontext.usuarios.First(o => (int)o.Regiao == regioesEnum);
                //    if(RemoverUsuario(usuario)) InserirUsuario(usuario);

                //}
                //else
                //{
                //    usuario = usuariosList.First();
                //    if (RemoverUsuario(usuario)) InserirUsuario(usuario);

                //}
                #endregion Código de FILA comentado

                return usuario;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario ObterUsuarioPorEmail(string email) 
        {
            Usuario usuario = new Usuario();
            Oportunidade[] oportunidade = new Oportunidade[] { };
            try
            {
                oportunidade = Dbcontext.oportunidades.FromSqlRaw("SELECT * FROM OPORTUNIDADES WHERE UsuarioEmailId = {0}", email).ToArray();
                usuario = Dbcontext.usuarios.First(a => a.EmailId == email);

                usuario.Oportunidades = oportunidade;

                
                
                return usuario;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool ExisteUsuario(string email) 
        {
            try
            {
                return Dbcontext.usuarios.Where(a => a.EmailId == email).ToArray().Length > 0;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        public JObject ConsultarCNPJ(string CNPJ)
        {
            WebResponse resp = null;
            WebRequest req = null;
            try
            {
                CNPJ = CNPJ.Contains("/") | CNPJ.Contains(".") | CNPJ.Contains("-") ? Regex.Replace(CNPJ, @"[^0-9a-zA-Z\._]", string.Empty) : CNPJ;

                var url = String.Format("https://publica.cnpj.ws/cnpj/{0}", CNPJ);

                req = WebRequest.Create(url);
                req.Method = "GET";

                resp = req.GetResponse();
                using Stream st = resp.GetResponseStream();

                using var reader = new StreamReader(st);
                var data = reader.ReadToEnd();

                JObject jso = JObject.Parse(data);
                return jso;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Métodos de Obtenção

        #region Métodos de Exclusão

        public bool RemoverUsuario(Usuario usuario)
        {
            try
            {
                EntityEntry<Usuario> usu = Dbcontext.usuarios.Remove(usuario);

                return usu != null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Métodos de Exclusão

        #region Métodos de Atualização
        public Usuario AtualizarUsuario(Usuario usuario)
        {
            Usuario usu = new Usuario();
            try
            {
                usu = Dbcontext.usuarios.First(a => a.EmailId == usuario.EmailId);
                usu = usuario;
                

                return usu;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Métodos de Atualização
    }
}
