namespace Zad1.Services
{
    public interface IProductWarehouseService
    {
        public bool checkIfOrderExists(int IdOrder);
        public int insertNewRecord(int IdWarehouse,int IdProduct,int IdOrder,int Amount,double Price);
    }
}
