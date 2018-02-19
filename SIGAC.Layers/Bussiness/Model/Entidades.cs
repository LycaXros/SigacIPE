using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGAC.Layers.Bussiness.Model
{
    public class Entidades: IDisposable
    {

        private SigacEntities _dbSigac;
        private SiathEntities _dbSiath;

        public SigacEntities Sigac
        {
            get
            {
                return _dbSigac;
            }
        }

        public SiathEntities Siath
        {
            get
            {
                return _dbSiath;
            }
        }

        public Entidades()
        {
            _dbSigac = new SigacEntities();
            _dbSiath = new SiathEntities();
        }

        public void Dispose()
        {
            _dbSiath.Dispose();
            _dbSigac.Dispose();
        }
    }
}
