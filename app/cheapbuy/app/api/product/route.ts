import { NextRequest, NextResponse } from "next/server";
import getConfig from 'next/config'

const { serverRuntimeConfig } = getConfig()

export async function GET(request: NextRequest) {
  const productId = request.nextUrl.searchParams.get('id')
  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Product/${productId}`, {
    headers: {
        'Content-Type': 'application/json',
    }
  })
  const result = await res.json()
  return NextResponse.json({result})
}
