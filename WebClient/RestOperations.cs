using System;

namespace WebClient
{
    public interface RestOperations
    {
        ResponseEntity<RS> Exchange<RQ, RS>(RequestEntity<RQ> requestEntity) where RQ : class;
    }
}