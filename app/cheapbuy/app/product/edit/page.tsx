"use client"

import { Product } from "@/app/page"
import Link from "next/link"
import { useRouter, useSearchParams } from "next/navigation"
import { FormEvent, useEffect, useState } from "react"
import { toast } from "react-toastify"

export default function EditProduct() {

    const { push } = useRouter();
    const searchParams = useSearchParams()
    const [brands, setBrands] = useState<any[]>([])
    const [product, setProduct] = useState<Product>({
         productId: '',
         productName: '',
         brand: '',
         price: 0,
         brandId: 0
    })
    
    const getAllBrands = async() => {
        try {
            const res = await fetch("/api/brands", {
                method: "GET",
            });
            const json = await res.json();
            setBrands(json.data);
        } catch (error) {
            toast.error(`Error getting brands: ${error}`,{
                position: "bottom-center",
                theme: "dark",
            }) 
        }
    }

    const getProduct = async() => {
        const productId = searchParams.get('id')
        try {
            const res = await fetch(`/api/product?id=${productId}`, {
                method: "GET",
            });
            const json = await res.json();
            setProduct(json.result);
        } catch (error) {
            toast.error(`Error getting product: ${error}`,{
                position: "bottom-center",
                theme: "dark",
            }) 
        }
    }
  
    useEffect(() => {
        getAllBrands()
        getProduct()
    }, [])
    
    async function onSubmit(e: FormEvent<HTMLFormElement>) {
        e.preventDefault()
        const formData = new FormData(e.currentTarget)
        formData.append("productId", product.productId)
        await fetch('/api/products', {
            method: 'PUT',
            body: formData
        })
        .then(async res => {
            if (res.status == 200){
                toast.success("Product edited successfully",{
                    position: "bottom-center",
                    theme: "dark",
                })
                push('/');
            } else {
                toast.error(res.statusText,{
                    position: "bottom-center",
                    theme: "dark",
                }) 
            }
        })
    }

    return (
        <form onSubmit={onSubmit}>
            <div className="grid gap-2 mb-6 grid-cols-2">
                <div className="m-1 col-span-2">
                    <label htmlFor="productId" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Id</label>
                    <input type="text" id="productId" 
                        value={product.productId} 
                        onChange={e => setProduct({...product ,productId: e.target.value })}
                        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" 
                        required disabled name="productId" />
                </div>
                <div className="m-1 col-span-2">
                    <label htmlFor="productName" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Name</label>
                    <input type="text" id="productName"
                        value={product.productName || ''}
                        onChange={e => setProduct({...product, productName: e.target.value })}
                        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        required name="productName" />
                </div>
                <div className="m-1 col-span-2">
                    <label htmlFor="brandId" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Brand</label>
                    <select id="brandId"
                        value={product?.brandId.toString()}
                        onChange={e => setProduct({...product ,brandId: Number(e.target.value) })}
                        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        required name="brandId"  >
                            <option value=""></option>
                            {brands.map((item, index) => (  
                                <option key={index} value={item.id}>{item.name}</option>
                            ))}
                    </select>
                </div>
                <div className="m-1 col-span-2">
                    <label htmlFor="price" className="block mb-2 text-sm font-medium text-gray-900 dark:text-white">Price</label>
                    <input type="number" id="price"
                        value={product.price.toString()}
                        onChange={e => setProduct({...product ,price: Number(e.target.value) })}
                        className="bg-gray-50 border border-gray-300 text-gray-900 text-sm rounded-lg focus:ring-blue-500 focus:border-blue-500 block w-full p-2.5 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
                        required  name="price" />
                </div>
                <div className="m-1 col-span-2">

                </div>
                <div className="m-1">
                    <button type="submit" className="inline-block bg-slate-500 text-white active:bg-slate-600 font-bold uppercase text-sm px-12 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 ease-linear transition-all duration-150">
                        Save
                    </button>
                </div>
                <div className="m-1">
                    <Link href="/"
                        className=" inline-block bg-slate-500 text-white active:bg-slate-600 font-bold uppercase text-sm px-6 py-3 rounded shadow hover:shadow-lg outline-none focus:outline-none mr-1 mb-1 ease-linear transition-all duration-150">
                        Cancel
                    </Link>
                </div>
            </div>
        </form>
    )
}