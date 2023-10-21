import Link from "next/link";
import { toast } from 'react-toastify';
import { useProductsContext, Product } from "../page";

export default function ProductItem(props: Product) {

    let { products, setProducts, allProducts, setAllProducts } = useProductsContext()

    const deleteProduct = async() => {
        await fetch('/api/products', {
            method: 'DELETE',
            body: JSON.stringify(props.productId),
            headers: {'Content-Type': 'application/json'},
        }).then((data) => {
            if (data.status == 200){         
                toast.success("Product deleted successfully!",{
                    position: "bottom-center",
                    theme: "dark",
                })       
                products = products.filter((p: { productId: any; }) => p.productId != props.productId)
                setProducts(products)
                allProducts = allProducts.filter((p: { productId: any; }) => p.productId != props.productId)
                setAllProducts(allProducts)
            } else {
                toast.error(data.statusText,{
                    position: "bottom-center",
                    theme: "dark",
                })    
            }
        }).catch(error => {
            toast.error(`Error on product deletion: ${error}`,{
                position: "bottom-center",
                theme: "dark",
            })
        });
    }

    return (
    <tr key={props.productId}>
        <td className="px-4 py-4 text-sm text-gray-500 dark:text-gray-300 whitespace-nowrap">
            <div className="inline-flex items-center gap-x-3">
                <span>{props.productId}</span>
            </div>
        </td>
        <td className="px-4 py-4 text-sm text-gray-700 dark:text-gray-200 whitespace-nowrap font-medium ">
            {props.productName}
        </td>
        <td className="px-4 py-4 text-sm text-gray-300 whitespace-nowrap">
            {props.brand}
        </td>
        <td className="px-4 py-4 text-sm text-gray-500 dark:text-gray-300 whitespace-nowrap">
            {props.price}
        </td>
        <td className="px-4 py-4 text-sm whitespace-nowrap">
            <div className="flex items-center gap-x-6">
            <button onClick={deleteProduct} aria-label="Delete Product" className="text-red-500 transition-colors duration-200 dark:hover:text-indigo-500 dark:text-red-300 hover:text-indigo-500 focus:outline-none">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                <path strokeLinecap="round" strokeLinejoin="round" d="M20.25 7.5l-.625 10.632a2.25 2.25 0 01-2.247 2.118H6.622a2.25 2.25 0 01-2.247-2.118L3.75 7.5m6 4.125l2.25 2.25m0 0l2.25 2.25M12 13.875l2.25-2.25M12 13.875l-2.25 2.25M3.375 7.5h17.25c.621 0 1.125-.504 1.125-1.125v-1.5c0-.621-.504-1.125-1.125-1.125H3.375c-.621 0-1.125.504-1.125 1.125v1.5c0 .621.504 1.125 1.125 1.125z" />
                </svg>
            </button>

            <Link aria-label="Edit Product" 
                href={`/product/edit?id=${props.productId}`}
                className="text-blue-500 transition-colors duration-200 hover:text-indigo-500 focus:outline-none">
                <svg xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24" strokeWidth="1.5" stroke="currentColor" className="w-6 h-6">
                    <path strokeLinecap="round" strokeLinejoin="round" d="M16.862 4.487l1.687-1.688a1.875 1.875 0 112.652 2.652L6.832 19.82a4.5 4.5 0 01-1.897 1.13l-2.685.8.8-2.685a4.5 4.5 0 011.13-1.897L16.863 4.487zm0 0L19.5 7.125" />
                </svg>
            </Link>
            </div>
        </td>
    </tr>
  )}