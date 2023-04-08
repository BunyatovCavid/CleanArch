using Domain.Entities;
using Domain.Interface.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUOW:IDisposable
    {
        public IMovieRepository _movie { get; }
        public IActorRepository  _actor { get; }
        public ICrossRepository _cross { get; }
        public Task SaveChange();
    }
}
