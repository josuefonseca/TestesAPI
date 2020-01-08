using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestesAPI.Models {
    public class MeninosModel {

        

        public class Boy {

            [JsonProperty("Id")]
            public int CD_BOY { get; set; }
            [JsonProperty("Nome")]
            public string NM_BOY { get; set; }
            [JsonProperty("Idade")]
            public int AGE_BOY { get; set; }
        }

        public class Toy {
            public int CD_TOY { get; set; }
            public string NM_TOY { get; set; }
            public int CD_TP_TOY { get; set; }
        }

        public class TP_Toy {
            public int CD_TP_TOY { get; set; }
            public string NM_TP_TOY { get; set; }
        }

        public class Boy_Toy {
            public int CD_BOY_TOY { get; set; }
            public int CD_BOY { get; set; }
            public int CD_TOY { get; set; }
            public DateTime DT_DONATION { get; set; }
        }

      
        public List<Boy> ListaMeninos(int id) {

            API_TESTESEntities banco = new API_TESTESEntities();
            if (id != 0)
                return (from b in banco.BOY  where b.ID_BOY == id select new Boy { CD_BOY = b.ID_BOY, NM_BOY = b.NM_BOY, AGE_BOY = b.AGE_BOY }).ToList();
            else
                return (from b in banco.BOY select new Boy { CD_BOY = b.ID_BOY, NM_BOY = b.NM_BOY, AGE_BOY = b.AGE_BOY }).ToList(); ;

        }

        public int GravaMenino(Boy newBoy) {
            
            API_TESTESEntities banco = new API_TESTESEntities();

            try {
                
                if(newBoy.CD_BOY == 0) {
                    var nb = new BOY { NM_BOY = newBoy.NM_BOY, AGE_BOY = newBoy.AGE_BOY };
                    nb.ID_BOY = (from b in banco.BOY select b.ID_BOY).Max() + 1;
                    banco.BOY.Add(nb);
                } else {
                    var editar = banco.BOY.Single(x => x.ID_BOY == newBoy.CD_BOY);
                    editar.NM_BOY = newBoy.NM_BOY;
                    editar.AGE_BOY = newBoy.AGE_BOY;
                }
                banco.SaveChanges();

                return 1;
            } catch {
                return 2;
            }


        }

        public int ExcluiMenino(Boy newBoy) {

            API_TESTESEntities banco = new API_TESTESEntities();

            try {

                var del = banco.BOY.Single(x => x.ID_BOY == newBoy.CD_BOY);
                banco.BOY.Remove(del);
                
                banco.SaveChanges();

                return 1;
            } catch {
                return 2;
            }


        }

    }
}