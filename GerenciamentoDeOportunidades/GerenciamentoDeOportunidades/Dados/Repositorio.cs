﻿using GerenciamentoDeOportunidades.Dados;
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
            //regioesEnum = regioesEnum - 1;
            Random rnd = new Random();
            Usuario[] usuariosList = new Usuario[] { };
            Usuario ultimoUsuario = new Usuario();
            Usuario usuario = new Usuario();
            try
            {

                Dbcontext.usuarios.Where(a => a.Regiao > 0);
                usuariosList = Dbcontext.usuarios.Where(a => a.Oportunidades.ToArray().Length <= 0 && (int)a.Regiao == regioesEnum).ToArray();

                if (usuariosList.Length == 0)
                {
                    if (Dbcontext.oportunidades.ToArray().Length > 0)
                    {
                        ultimoUsuario = Dbcontext.usuarios.LastOrDefault(a => a.Oportunidades.Contains(Dbcontext.oportunidades.ToArray().LastOrDefault()) && (int)a.Regiao == regioesEnum);
                        usuariosList = Dbcontext.usuarios.Where(u => u != ultimoUsuario && (int)u.Regiao == regioesEnum).ToArray();
                        usuario = usuariosList[rnd.Next(usuariosList.Length)];
                    }
                    usuariosList = Dbcontext.usuarios.Where(u => (int)u.Regiao == regioesEnum).ToArray();
                    if (usuariosList.Length > 0)
                    {
                        usuario = usuariosList[rnd.Next(usuariosList.Length)];
                    }
                    

                }
                else
                {
                    usuario = usuariosList.First();
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
                Usuario[] usuRetorno = Dbcontext.usuarios.Where(a => a.EmailId == email).ToArray();
                if(usuRetorno.Length >0)
                {
                    usuario = usuRetorno.First();
                }
                usuario.Oportunidades = oportunidade;

                
                
                return usuario;
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
