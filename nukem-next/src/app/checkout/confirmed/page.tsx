import { prisma } from '@/lib/prisma'
import { getSession } from '@/lib/session'
import { redirect } from 'next/navigation'
import Link from 'next/link'

export default async function CheckoutConfirmedPage({ searchParams }: { searchParams: { orderId?: string } }) {
  const session = await getSession()
  if (!session) redirect('/login')

  const sp = await searchParams
  const orderId = parseInt(sp.orderId || '0', 10)
  if (!orderId) redirect('/')

  const order = await prisma.order.findUnique({ where: { id: orderId } })
  if (!order) redirect('/')

  if (order.userId !== session.userId && !session.admin) {
    redirect('/')
  }

  return (
    <div className="container mx-auto px-4 py-24 text-center">
      <div className="max-w-2xl mx-auto bg-white/5 border border-white/10 p-12 rounded-3xl shadow-[0_0_50px_rgba(16,185,129,0.1)]">
        <div className="w-24 h-24 bg-green-500/20 text-green-500 rounded-full flex items-center justify-center mx-auto mb-8">
          <svg className="w-12 h-12" fill="none" stroke="currentColor" viewBox="0 0 24 24">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M5 13l4 4L19 7" />
          </svg>
        </div>
        <h2 className="text-4xl font-black text-white mb-6">TRANSACTION COMPLETE</h2>
        <p className="text-xl text-gray-400 mb-8">
          Your order #{order.id} for {order.itemName} has been confirmed.
          We are currently preparing it for delivery.
        </p>
        <Link 
          href="/"
          className="inline-block py-4 px-8 bg-white/10 hover:bg-white/20 text-white font-bold rounded-xl transition-colors"
        >
          RETURN TO BASE
        </Link>
      </div>
    </div>
  )
}
