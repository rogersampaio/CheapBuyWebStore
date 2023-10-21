import { useProductsContext } from "../page";
import ProductItem from "./productItem";
import TableHeader from "./tableHeader";

export default function ProductTable() {

    let { products } = useProductsContext()

    return (
    <div className="flex flex-col">
        <div className="-mx-4 -my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
            <div className="inline-block min-w-full py-2 align-middle md:px-6 lg:px-8">
                <div className="overflow-hidden border border-gray-200 dark:border-gray-700 md:rounded-lg">
                    <table className="min-w-full divide-y divide-gray-200 dark:divide-gray-700">
                        <TableHeader />
                        <tbody className="bg-white divide-y divide-gray-200 dark:divide-gray-700 dark:bg-gray-900">
                            {products?.map((item, index) => (  
                              <ProductItem key={index} 
                                productId={item.productId}
                                productName={item.productName}
                                brandId={item.brandId}
                                brand={item.brand}
                                price={item.price}
                                />
                            ))}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
  )}