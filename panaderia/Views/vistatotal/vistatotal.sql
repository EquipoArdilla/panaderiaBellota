select * from producto
INNER JOIN medida ON producto.medidaId = medida.Id
inner join familia on producto.familiaId = familia.Id
inner join linea on familia.Id = linea.Id
inner join usuario on producto.usuarioId = usuario.Id
inner join rolusuario on usuario.Id = rolusuario.Id
inner join compra on producto.id = compra.productoId
inner join proveedor on compra.proveedor_rut =proveedor.rut
inner join detalle_receta on medida.Id = detalle_receta.medidaId
/*inner join detalle_receta on producto.Id =detalle_receta.productoId*/
inner join receta on detalle_receta.recetaId = receta.Id
inner join produccion on receta.Id = produccion.recetaId

/*select * from proveedor*/

