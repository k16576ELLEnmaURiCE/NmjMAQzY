// 代码生成时间: 2025-10-23 09:25:56
// MembershipPointsSystem.cs
// 会员积分系统

using System;
using System.Collections.Generic;
using System.Linq;

namespace MembershipPointsSystem
{
    public class Member
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public Member(string id, string name)
        {
            Id = id;
            Name = name;
            Points = 0; // 初始化积分为0
        }
    }

    public class PointsManager
    {
        private List<Member> members;

        public PointsManager()
        {
            members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(nameof(member), "Member cannot be null");
            }

            if (members.Any(m => m.Id == member.Id))
            {
                throw new InvalidOperationException("Member with the same ID already exists");
            }

            members.Add(member);
        }

        public void AwardPoints(string memberId, int points)
        {
            if (string.IsNullOrEmpty(memberId))
            {
                throw new ArgumentException("Member ID cannot be null or empty", nameof(memberId));
            }

            if (points <= 0)
            {
                throw new ArgumentException("Points must be positive", nameof(points));
            }

            var member = members.FirstOrDefault(m => m.Id == memberId);
            if (member == null)
            {
                throw new InvalidOperationException("Member not found");
            }

            member.Points += points; // 增加积分
        }

        public void RedeemPoints(string memberId, int points)
        {
            if (string.IsNullOrEmpty(memberId))
            {
                throw new ArgumentException("Member ID cannot be null or empty", nameof(memberId));
            }

            if (points <= 0)
            {
                throw new ArgumentException("Points must be positive", nameof(points));
            }

            var member = members.FirstOrDefault(m => m.Id == memberId);
            if (member == null)
            {
                throw new InvalidOperationException("Member not found");
            }

            if (member.Points < points)
            {
                throw new InvalidOperationException("Not enough points to redeem");
            }

            member.Points -= points; // 减少积分
        }

        public void PrintMemberPoints(string memberId)
        {
            var member = members.FirstOrDefault(m => m.Id == memberId);
            if (member == null)
            {
                throw new InvalidOperationException("Member not found");
            }

            Console.WriteLine($"Member {member.Name} has {member.Points} points");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var pointsManager = new PointsManager();

                pointsManager.AddMember(new Member("001", "John Doe"));
                pointsManager.AwardPoints("001", 100);
                pointsManager.PrintMemberPoints("001");
                pointsManager.RedeemPoints("001", 50);
                pointsManager.PrintMemberPoints("001");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}