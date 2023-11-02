import {  NextResponse } from "next/server";
import getConfig from 'next/config'

const { serverRuntimeConfig } = getConfig()

export async function GET() {
  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Product`, {
    headers: {
        'Content-Type': 'application/json',
    }
  })
  const result = await res.json()
  return NextResponse.json({result})
}

export async function POST(request: Request) {
  const formData = await request.formData()

  const productId = formData.get('productId')
  const productName = formData.get('productName')
  const brandId = formData.get('brandId')
  const price = formData.get('price')

  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Product`, {
    body: JSON.stringify({ productId, productName, brandId, price }),
    headers: {
      'Content-Type': 'application/json',
    },
    method: "POST"
  })

  if (res?.status == 200){
    return NextResponse.json({ message: "OK", success: true })
  } else
  {
    return NextResponse.json({ error: 'Product already exist' }, { status: 501 })
  }

}

export async function PUT(request: Request) {
  const formData = await request.formData()
  const productId = formData.get('productId')
  const productName = formData.get('productName')
  const brandId = formData.get('brandId')
  const price = formData.get('price')

  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Product`, {
    body: JSON.stringify({ productId, productName, brandId, price }),
    headers: {
      'Content-Type': 'application/json',
    },
    method: "PUT"
  })

  if (res?.status == 200){
    return NextResponse.json({ message: "OK", success: true })
  }
}

export async function DELETE(request: Request) {
  const productId = await request.json()
  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Product?productId=${productId}`, {
    method: "DELETE"
  })
  return res
}