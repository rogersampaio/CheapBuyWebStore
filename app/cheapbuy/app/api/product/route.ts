import { NextRequest, NextResponse } from "next/server";

export async function GET(request: NextRequest) {
  const productId = request.nextUrl.searchParams.get('id')
  const res = await fetch(`http://localhost:5078/Product/${productId}`, {
    headers: {
        'Content-Type': 'application/json',
    }
  })
  const result = await res.json()
  return NextResponse.json({result})
}
