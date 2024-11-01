using Amazon.Core.Modelos;
using Amazon.Infraestructura.Repositorio.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon.Test
{
    [TestFixture]
    public class CarritoTests
    {
        private Mock<ICarritoRepositorio<Producto>> _carritoRepositorioMock;
        private List<Producto> productos;
        private Producto productoTest1;
        private Producto productoTest2;

        [SetUp]
        public void SetUp()
        {
            _carritoRepositorioMock = new Mock<ICarritoRepositorio<Producto>>();
            productos = new List<Producto>();

            productoTest1 = new Producto
            {
                Id = 1,
                Nombre = "Laptop",
                Precio = 1200,
                Cantidad = 1
            };

            productoTest2 = new Producto
            {
                Id = 2,
                Nombre = "Mouse",
                Precio = 50,
                Cantidad = 1
            };

            _carritoRepositorioMock.Setup(repo => repo.Agregar(It.IsAny<Producto>()))
                                 .Callback<Producto>(producto => productos.Add(producto));

            _carritoRepositorioMock.Setup(repo => repo.ObtenerTodos())
                                  .ReturnsAsync(() => productos);
        }

        [Test]
        public async Task CarritoRepositorio_ObtenerTodos_NoEstaVacio()
        {
            // Act
            await _carritoRepositorioMock.Object.Agregar(productoTest1);
            await _carritoRepositorioMock.Object.Agregar(productoTest2);
            var productos = await _carritoRepositorioMock.Object.ObtenerTodos();

            // Assert
            Assert.IsNotEmpty(productos);
        }
    }
}
