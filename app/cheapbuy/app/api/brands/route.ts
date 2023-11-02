import { NextResponse } from "next/server";
import getConfig from 'next/config'

const { serverRuntimeConfig } = getConfig()

export async function GET() {
  const res = await fetch(`${serverRuntimeConfig.cheapBuyApiURL}/Brand`, {
    headers: {
        'Content-Type': 'application/json',
    }
  })
  const data = await res.json()
  return NextResponse.json({data})
}