import { NextResponse } from "next/server";

export async function GET() {
  //TODO: Enable CORS or run NextJS to use Local HTTPS: 'https://localhost:7147/Product'
  const res = await fetch('http://localhost:5078/Brand', {
    headers: {
        'Content-Type': 'application/json',
    }
  })
  const data = await res.json()
  return NextResponse.json({data})
}