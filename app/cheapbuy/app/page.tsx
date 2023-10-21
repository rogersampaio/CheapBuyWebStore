"use client";

import { createContext, useContext, useEffect, useState} from "react"
import 'tailwindcss/tailwind.css'
import Link from "next/link"
import { toast } from "react-toastify"
import ProductTable from "./components/productTable"
import ProductFilter from "./components/productFilter";

export type Product = {
  productId: string
  productName: string
  brandId: number
  brand: string
  price: number
}

type ContextType = {
  products: Product[];
  setProducts: (products: Product[]) => void;
  allProducts: Product[];
  setAllProducts: (allProducts: Product[]) => void;
}

export const ProductsContext = createContext<ContextType | undefined>(undefined)

export const useProductsContext = () => {
  const context = useContext(ProductsContext);
  if (!context) {
    throw new Error('useProductsContext must be used inside the Home');
  }
  return context;
}

export default function Home() {

  const [products, setProducts] = useState<ContextType['products']>([]);
  const [allProducts, setAllProducts] = useState<ContextType['allProducts']>([]);

  const getAllProducts = async () => {
    try {
      const res = await fetch("/api/products", {
        method: "GET",
      });
      const json = await res.json()
      setProducts(json.result)
      setAllProducts(json.result)
    } catch (error) {
      toast.error(`Get All Products error: ${error}`,{
        position: "bottom-center",
        theme: "dark",
      }) 
    }
  }
 
  useEffect(() => {
    getAllProducts()
  }, [])

  return (
    <ProductsContext.Provider value={{products, setProducts, allProducts, setAllProducts}}>
    <div className="grid gap-6 mb-6 grid-cols-3">
        
        <div className="col-span-2">
          <ProductFilter/>
        </div>
        
        <Link href="/product/add" className=" inline-block bg-slate-500 text-white active:bg-slate-600 font-bold uppercase text-sm px-6 py-4 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150">
            Add Product
        </Link>

        <div className="mb-6 col-span-3">
            <ProductTable/>
        </div>
      
    </div>    
    </ProductsContext.Provider>
  )
}
