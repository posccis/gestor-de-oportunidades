﻿using Newtonsoft.Json.Linq;
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

        #region Métodos de Inserção
        public bool InserirUsuario(Usuario usuario) 
        {
            int retorno = 0;
            try
            {
                Dbcontext.usuarios.Add(usuario);
                retorno =  Dbcontext.SaveChanges();

                return retorno > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool InserirOportunidade(Oportunidade oportunidade)
        {
            int retorno = 0;
            try
            {
                Dbcontext.oportunidades.Add(oportunidade);
                retorno = Dbcontext.SaveChanges();
                return retorno > 0;
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
            regioesEnum = regioesEnum - 1;
            Random rnd = new Random();
            Usuario[] usuariosList = new Usuario[] {};
            Usuario ultimoUsuario = new Usuario();
            Usuario usuario = new Usuario();
            try
            {
                usuariosList = Dbcontext.usuarios.Where(a => a.Oportunidades.ToArray().Length == 0 && (int)a.Regiao == regioesEnum).ToArray();

                if (usuariosList.Length == 0)
                {
                    ultimoUsuario = Dbcontext.usuarios.LastOrDefault(a => a.Oportunidades.Contains(Dbcontext.oportunidades.Last()) && (int)a.Regiao == regioesEnum);
                    usuariosList = Dbcontext.usuarios.Where(u => u != ultimoUsuario && (int)u.Regiao == regioesEnum).ToArray();
                    usuario = usuariosList[rnd.Next(usuariosList.Length)];

                }
                else
                {
                    usuario = usuariosList.First();
                }

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
            int retorno = 0;
            try
            {
                Dbcontext.usuarios.Remove(usuario);
                retorno = Dbcontext.SaveChanges();

                return retorno > 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion Métodos de Exclusão

        #region Métodos de Atualização
        public bool AtualizarUsuario(Usuario usuario)
        {
            int retorno = 0;
            try
            {
                Dbcontext.usuarios.Update(usuario);

                retorno = Dbcontext.SaveChanges();

                return retorno > 0;

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Métodos de Atualização
    }
}
