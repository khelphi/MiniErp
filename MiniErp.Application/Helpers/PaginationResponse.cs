using System;
using System.Collections.Generic;
using System.Text;

namespace MiniErp.Application.Helpers
{
    public class PaginationResponse<T> where T : class
    {
        ///<sumary>
        /// Resposta de um requisição paginada
        ///</sumary>
        public int _pageSize { get; set; }

        ///<sumary>
        /// Página atual
        ///</sumary>
        public int _page { get; set; }

        ///<sumary>
        /// Total de registros
        ///</sumary>
        public int _total { get; set; }

        ///<sumary>
        /// Resultado paginado
        ///</sumary>
        public T[] Items { get; set; }

    }
}
