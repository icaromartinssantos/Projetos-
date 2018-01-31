using Agenda.Domain;
using Agenda.Infra.DataContext;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Agenda.Api.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ContatoController : ApiController
    {
        private AgendaDataContext db = new AgendaDataContext();

        [EnableCors(origins:"*", headers:"*", methods:"*")]
        [Route("contato")]
        public HttpResponseMessage GetContato()
        {
            var result = db.contato.Include("Operadora").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("operadora")]
        public HttpResponseMessage GetOperadora()
        {
            var result = db.operadora.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("operadora/{IDoperadora}/contato")]
        public HttpResponseMessage GetContatoBYOperadora(int IDoperadora)
        {
            var result = db.contato.Include("Operadora").Where(x => x.IDoperadora == IDoperadora).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [Route("contato/{IDcontato}")]
        public HttpResponseMessage GetContatoBYID(int IDcontato)
        {
            var result = db.contato.Include("Operadora").Where(x => x.IDcontato == IDcontato).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);

        }

        [HttpPost]
        [Route("contato")]
        public HttpResponseMessage PostContato( Contato contato )
        {

            if(contato == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {

                var newContato = new Contato
                {
                    Nome= contato.Nome,
                    Telefone= contato.Telefone,
                    Data = contato.Data,
                    IDoperadora = contato.operadora?.IDoperadora ?? 0,
                    operadora = null
                };
                
                db.contato.Add(newContato);
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir contato");
            }
            

        }

        [HttpDelete]
        [Route("contato")]
        public HttpResponseMessage PostContato(int IDcontato)
        {
            if (IDcontato <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.contato.Remove(db.contato.Find(IDcontato));
                db.SaveChanges();

                var result = IDcontato;
                return Request.CreateResponse(HttpStatusCode.OK, "Produto Excluido. ");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir contato");
            }


        }

        [HttpPatch]
        [Route("contato")]
        public HttpResponseMessage PatchContato(Contato contato)
        {
            if (contato == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Contato>(contato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao Alterar contato");
            }


        }


        [HttpPut]
        [Route("contato")]
        public HttpResponseMessage PutContato(Contato contato)
        {
            if (contato == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            try
            {
                db.Entry<Contato>(contato).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = contato;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir contato");
            }


        }




        protected override void Dispose(bool disposing)
        {
       
                db.Dispose();
            
        }

     
    }
}