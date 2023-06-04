using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/GalambListaDB/"
            )]

        List<Galamb> GalambListaDB();

        [OperationContract]
        List<Galamb> GalambListaDBCS();
       
        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/GalambPostDB/"
            )]

        string GalambPostDB(Galamb galamb);

        [OperationContract]
        string GalambPostDBCS(Galamb galamb);

        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambPutDB"
           )]

        string GalambPutDB(Galamb galamb);

        [OperationContract]
        string GalambPutDBCS(Galamb galamb);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambDeleteDB?id={id}"
           )]

        string GalambDeleteDB(int id);

        [OperationContract]
        string GalambDeleteDBCS(int id);

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyGalambAdatai/"
            )]

        Galamb EgyGalambGet();

        [OperationContract]
        Galamb EgyGalambGetCS();

        [OperationContract]
        Galamb EgyGalambPostCS();

        [OperationContract]
        [WebInvoke(Method = "POST",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/EgyGalambHozzaAdas/"
            )]
        Galamb EgyGalambPost();

        [OperationContract]
        [WebInvoke(Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            UriTemplate = "/GalambLista/"
            )]
        List<Galamb> GalambLista();

        [OperationContract]
        List<Galamb> GalambListaCS();

        //4. uj keresek hozzaadasa: parameterezheto POST keressel galamb hozzaadasa, egyedi id-vel
        [OperationContract]
        [WebInvoke(Method = "POST",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambPost"
            )]
        //mindketto string tipusu ertekkel ter vissza!
        string GalambPost(Galamb galamb);

        [OperationContract]
        string GalambPostCS(Galamb galamb);
        //modositasok utan mentés, Program.cs futtatas. Ezzel generalodik a Host.exe a Debug bin mappába, amit utána rendszergazda joggal kell futtatni

        //5. modositas put keressel
        [OperationContract]
        [WebInvoke(Method = "PUT",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambPut"
           )]

        string GalambPut(Galamb galamb);

        [OperationContract]
        string GalambPutCS(Galamb galamb);


        //7. galamb torlese id alapjan
        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambDelete"
           )]
        //ezen a kulcson varja a paramétert pl {"id":792}. ha nem egyezik a kulcs, nem lesz adat!
        string GalambDelete(int id);

        [OperationContract]
        string GalambDeleteCS(int id);

        //9. galamb torlese id alapjan, url parameter
        [OperationContract]
        [WebInvoke(Method = "DELETE",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambDeleteParameter?id={id}"
           )]
        //urlben és függvényben a paramérenév legyen azonos!
        string GalambDeleteParameter(int id);

        [OperationContract]
        [WebInvoke(Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           UriTemplate = "/GalambGetID?id={id}"
           )]

        Galamb GalambGetID(int id);

        [OperationContract]
        Galamb GalambGetIDCS(int id);
    }

    [DataContract]

    public class Record
    {
        [DataMember]
        public int? ID { get; set; }
    }

    [DataContract]

    public class Galamb : Record
    {
        [DataMember]

        public string Nev { get; set; }

        [DataMember]

        public string Gazda { get; set; }

        [DataMember]

        public byte Eletkor { get; set; }

        [DataMember]

        public string Fajta { get; set; }

        [DataMember(IsRequired = true)]

        public bool? Nem { get; set; }

        [DataMember]

        public byte LabakSzama { get; set; }

    }

}
