import {  NextResponse } from "next/server";

export async function GET() {
  //TODO: Enable CORS or run NextJS to use Local HTTPS: 'https://localhost:7147/Product'
  const res = await fetch('http://localhost:5078/Product', {
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

  const res = await fetch('http://localhost:5078/Product', {
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

  const res = await fetch('http://localhost:5078/Product', {
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
  const res = await fetch(`http://localhost:5078/Product?productId=${productId}`, {
    method: "DELETE"
  })
  return res
}